using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Official.Domain.Model.Authorization;
using Official.Persistence.EFCore.Context;
using Official.Persistence.EFCore.Identity;

namespace Official.Persistence.EFCore.Utility
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider services)
        {
            using (var context = services.GetRequiredService<STEDbContext>())
            {

                // شناسایی کنترلر ها
                var allController = Assembly.Load("Official.Interface.RestApi").GetTypes()
                    .Where(type => type.BaseType.Name == "ControllerBase")
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any()).ToList()
                    .Select(x => new
                    {
                        Controller = x.DeclaringType?.Name,
                        Action = x.Name,
                        ReturnType = x.ReturnType.Name,
                        Attributes = x.GetCustomAttributes().Where(a => a.GetType().Name == "AuthorizeAttribute").Select(a => a.GetType().GetProperty("Policy")?.GetValue(a, null)).FirstOrDefault()
                        //String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", "")))
                    })
                    .OrderBy(x => x.Controller).ThenBy(x => x.Action)
                    .ToList().Select(a => new ControllerInfo()
                    {
                        Controller = a.Controller.Replace("Controller", "").Replace("Query", ""),
                        Action = a.Action,
                        Policy = (a.Attributes ?? string.Empty) as string
                    }).Where(a => a.Policy.EndsWith("Policy")).ToList();
                var alreadyController = context.ControllerInfos.ToList();
                var removeController = alreadyController.Where(a => !allController.Any(b => a.Controller == b.Controller && a.Action == b.Action && a.Policy == b.Policy)).ToList();
                allController.ToList().ForEach(c =>
                {
                    var existsController = alreadyController.FirstOrDefault(a => a.Controller == c.Controller && a.Action == c.Action && a.Policy == c.Policy);
                    if (existsController != null)
                    {
                        var item = allController.SingleOrDefault(a => a.Controller == existsController.Controller && a.Action == existsController.Action && a.Policy == existsController.Policy);
                        allController.Remove(item);
                    }
                });
                context.ControllerInfos.RemoveRange(removeController);
                context.ControllerInfos.AddRange(allController);
                context.SaveChanges();



                // ایجاد دسترسی برای ادمین
                List<AppRoleClaim> appRoleClaims = new List<AppRoleClaim>();
                var roleIdAdmin = context.Roles.Where(a => a.Name.ToLower().Trim().ToString() == "admin")
                    .Select(a => a.Id).FirstOrDefault();
                var actionIdList = context.ControllerInfos.Select(a => a.Id).ToList();
                var noExistsInRoleClaimAdmin = actionIdList
                    .Where(actionId => !context.RoleClaims.Any(b => b.ClaimType == actionId.ToString() && b.RoleId == roleIdAdmin)).ToList();
                var existsRoleClaimAdmin = context.RoleClaims.Where(a =>
                    a.RoleId == roleIdAdmin && actionIdList.Any(actionId => actionId.ToString() == a.ClaimType && a.ClaimValue == "false")).ToList();
                existsRoleClaimAdmin.ForEach(a => { a.ClaimValue = "true"; });
                noExistsInRoleClaimAdmin.ForEach(actionId =>
                {
                    AppRoleClaim appRoleClaim = new AppRoleClaim()
                    {
                        ClaimType = actionId.ToString(),
                        ClaimValue = "true",
                        RoleId = roleIdAdmin
                    };
                    appRoleClaims.Add(appRoleClaim);
                });
                context.RoleClaims.UpdateRange(existsRoleClaimAdmin);
                context.RoleClaims.AddRange(appRoleClaims);
                context.SaveChanges();

            }
        }
    }
}