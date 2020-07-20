using Microsoft.AspNetCore.Identity;
using Official.Persistence.EFCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Official.Domain.Model.Security.ISecurityRepository;
using Official.Persistence.EFCore.Context;
using Microsoft.EntityFrameworkCore.Storage;
using Official.Domain.Model.Authorization;

namespace Official.Persistence.EFCore.Repositories
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly STEDbContext _context;
        private IDbContextTransaction _tran;

        public SecurityRepository(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, STEDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context; 
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private async Task<int> Save()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Login(string userName, string password)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(userName, password, false, false);
                return result.Succeeded;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Register(string userName, string password)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> IsExistsRoleNameAsync(string roleName)
        {
            try
            {
                AppRole role = await _roleManager.FindByNameAsync(roleName);
                return role != null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> CreateRoleAsync(string roleName)
        {
            try
            {
                AppRole role = new AppRole()
                {
                    Name = roleName
                };
                IdentityResult result = await _roleManager.CreateAsync(role);
                return result.Succeeded;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<long> GetRoleIdByRoleNameAsync(string roleName)
        {
            try
            {
                AppRole role = await _roleManager.FindByNameAsync(roleName);
                return role.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> CreateRoleUserAsync(long roleId, List<long> userIds)
        {
            try
            {
                var userRoleList = new List<AppUserRole>();
                foreach (var userId in userIds)
                {
                    var userRole = new AppUserRole() { RoleId = roleId, UserId = userId };
                    userRoleList.Add(userRole);
                }
                await _context.AddRangeAsync(userRoleList);
                return await Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> CreateRoleClaims(RoleClaimTransfer roleClaimTransfer)
        {
            try
            {
                var appRoleClaimList = new List<AppRoleClaim>();
                foreach (var claimValue in roleClaimTransfer.ClaimValue)
                {
                    var appRoleClaim = new AppRoleClaim()
                    {
                        RoleId = roleClaimTransfer.RoleId,
                        ClaimType = roleClaimTransfer.ClaimType,
                        ClaimValue = claimValue
                    };
                    appRoleClaimList.Add(appRoleClaim);
                }
                await _context.AddRangeAsync(appRoleClaimList);
                return await Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void BeginTransaction()
        {
            _tran = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _tran.Commit();
            _tran.Dispose();
        }

        public void Rollback()
        {
            _tran.Rollback();
            _tran.Dispose();
        }

    }
}
