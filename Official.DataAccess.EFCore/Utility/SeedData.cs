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
using static Official.Persistence.EFCore.Utility.Constant;

namespace Official.Persistence.EFCore.Utility
{
    public class SeedData
    {

        public static void InitializeAsync(IServiceProvider services)
        {
            using (var context = services.GetRequiredService<STEDbContext>())
            {

                // شناسایی کنترلر ها
                var allController = Assembly.Load(RestApi).GetTypes()
                    .Where(type => type.BaseType.Name == ControllerType)
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => new
                    {
                        Controller = x.DeclaringType?.Name,
                        Action = x.Name,
                        ReturnType = x.ReturnType.Name,
                        Attributes = x.GetCustomAttributes().Where(a => a.GetType().Name == AuthorizeType).Select(a => a.GetType().GetProperty(PolicyPostfix)?.GetValue(a, null)).FirstOrDefault()
                        //String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", "")))
                    })
                    .OrderBy(x => x.Controller).ThenBy(x => x.Action)
                    .ToList().Select(a => new ControllerInfo()
                    {
                        Controller = a.Controller.Replace(ControllerPostfix1, "").Replace(ControllerPostfix2, ""),
                        Action = a.Action,
                        Policy = (a.Attributes ?? string.Empty) as string
                    }).Where(a => a.Policy.EndsWith(PolicyPostfix)).ToList();
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

                var removeUserClaim = context.AspNetUserClaims.Where(a => removeController.Any(r => r.Id.ToString() == a.ClaimType)).ToList();
                var removeRoleClaim = context.AspNetRoleClaims.Where(a => removeController.Any(r => r.Id.ToString() == a.ClaimType)).ToList();

                context.AspNetUserClaims.RemoveRange(removeUserClaim);
                context.AspNetRoleClaims.RemoveRange(removeRoleClaim);

                context.ControllerInfos.RemoveRange(removeController);
                context.ControllerInfos.AddRange(allController);

                context.SaveChanges();



                // ایجاد دسترسی کامل برای پشتیبان سیستم
                List<AppRoleClaim> appRoleClaims = new List<AppRoleClaim>();
                var roleIdAdmin = context.Roles.Where(a => a.Name.ToLower().Trim().ToString() == DefaultRole)
                    .Select(a => a.Id).FirstOrDefault();
                var actionIdList = context.ControllerInfos.Select(a => a.Id).ToList();
                var noExistsInRoleClaimAdmin = actionIdList
                    .Where(actionId => !context.RoleClaims.Any(b => b.RoleId == roleIdAdmin && b.ClaimType == ControllerClaim && b.ClaimValue.ToString() == actionId.ToString())).ToList();
                var existsRoleClaimAdmin = context.RoleClaims.Where(a =>
                    a.RoleId == roleIdAdmin && actionIdList.Any(actionId => a.ClaimType == ControllerClaim && a.ClaimValue == actionId.ToString())).ToList();
                //existsRoleClaimAdmin.ForEach(a => { a.ClaimValue = "true"; });
                noExistsInRoleClaimAdmin.ForEach(actionId =>
                {
                    AppRoleClaim appRoleClaim = new AppRoleClaim()
                    {
                        ClaimType = ControllerClaim,
                        ClaimValue = actionId.ToString(),
                        RoleId = roleIdAdmin
                    };
                    appRoleClaims.Add(appRoleClaim);
                });
                //context.RoleClaims.UpdateRange(existsRoleClaimAdmin);
                context.RoleClaims.AddRange(appRoleClaims);
                context.SaveChanges();

            }
        }
    }
}