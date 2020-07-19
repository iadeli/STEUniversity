﻿using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Official.Application.Contracts.Command.Log.ApiLogItem;
using Official.Framework.Application;
using Official.Persistence.EFCore.Utility;

namespace Official.Interface.RestApi.Middleware
{
    public class ApiLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private ICommandBus _bus;

        public ApiLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ICommandBus bus)
        {
            try
            {
                _bus = bus;
                var request = httpContext.Request;
                if (request.Path.StartsWithSegments(new PathString("/api")))
                {
                    var stopWatch = Stopwatch.StartNew();
                    var requestTime = DateTime.UtcNow;
                    var requestBodyContent = await ReadRequestBody(request);
                    var originalBodyStream = httpContext.Response.Body;
                    using (var responseBody = new MemoryStream())
                    {
                        var response = httpContext.Response;
                        response.Body = responseBody;
                        await _next(httpContext);
                        stopWatch.Stop();

                        string responseBodyContent = null;
                        responseBodyContent = await ReadResponseBody(response);
                        await responseBody.CopyToAsync(originalBodyStream);

                        await SafeLog(requestTime,
                            stopWatch.ElapsedMilliseconds,
                            response.StatusCode,
                            request.Method,
                            request.Path,
                            request.QueryString.ToString(),
                            requestBodyContent,
                            responseBodyContent);
                    }
                }
                else
                {
                    await _next(httpContext);
                }
            }
            catch (Exception ex)
            {
                await _next(httpContext);
            }
        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            request.EnableRewind();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body.Seek(0, SeekOrigin.Begin);

            return bodyAsText;
        }

        private async Task<string> ReadResponseBody(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var bodyAsText = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return bodyAsText;
        }

        private async Task SafeLog(DateTime requestTime,
                            long responseMillis,
                            int statusCode,
                            string method,
                            string path,
                            string queryString,
                            string requestBody,
                            string responseBody)
        {
            if (path.ToLower().StartsWith("/api/user"))
            {
                requestBody = "(Request logging disabled for /api/user)";
                responseBody = "(Response logging disabled for /api/user)";
            }

            //if (requestBody.Length > 100)
            //{
            //    requestBody = $"(Truncated to 100 chars) {requestBody.Substring(0, 100)}";
            //}

            //if (responseBody.Length > 100)
            //{
            //    responseBody = $"(Truncated to 100 chars) {responseBody.Substring(0, 100)}";
            //}

            //if (queryString.Length > 100)
            //{
            //    queryString = $"(Truncated to 100 chars) {queryString.Substring(0, 100)}";
            //}

            var apiLogDto = new CreateApiLogCommand()
            {
                CreatedBy = new UserResolverService(new HttpContextAccessor())?.GetUser(),
                RequestTime = requestTime,
                ResponseMillis = responseMillis,
                StatusCode = statusCode,
                Method = method,
                Path = path,
                QueryString = queryString,
                RequestBody = requestBody,
                ResponseBody = responseBody
            };

            await _bus.Dispatch<CreateApiLogCommand, long>(apiLogDto);

            //StringBuilder sb = new StringBuilder();
            //sb.Append(path);
            //File.AppendAllText(@"C:\temp\" + "log.txt", sb.ToString());
            //sb.Clear();
        }
    }
}
