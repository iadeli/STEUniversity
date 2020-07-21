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
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NotImplementedException = System.NotImplementedException;

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

        public List<long> GetControllerIdByType(string entityName, string policy)
        {
            try
            {
                var controllerIds = _context.ControllerInfos.Where(a => a.Controller == entityName && a.Policy == policy).Select(a => a.Id).ToList();
                return controllerIds;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task RemoveRoleClaims(List<RoleClaimTransfer> roleClaimTransfers)
        {
            try
            {
                var roleClaims = await _context.RoleClaims.Where(a =>
                    roleClaimTransfers.Any(b => b.RoleId == a.RoleId && b.ClaimType == a.ClaimType && b.ClaimValue == a.ClaimValue)).ToListAsync();
                _context.RemoveRange(roleClaims);
                await Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task CreateRoleClaims(List<RoleClaimTransfer> roleClaimTransfers)
        {
            try
            {
                var transfers = roleClaimTransfers;
                var existsRoleClaim = await _context.RoleClaims.Where(a => transfers.Any(b =>
                    b.RoleId == a.RoleId && b.ClaimType == a.ClaimType && b.ClaimValue == a.ClaimValue)).ToListAsync();
                roleClaimTransfers = roleClaimTransfers.Where(a => !existsRoleClaim.Any(b =>
                    b.RoleId == a.RoleId && b.ClaimType == a.ClaimType && b.ClaimValue == a.ClaimValue)).ToList();

                var roleClaimList = new List<AppRoleClaim>();
                foreach (var roleClaim in roleClaimTransfers)
                {
                    var appRoleClaim = new AppRoleClaim()
                    {
                        RoleId = roleClaim.RoleId,
                        ClaimType = roleClaim.ClaimType,
                        ClaimValue = roleClaim.ClaimValue
                    };
                    roleClaimList.Add(appRoleClaim);
                }
                await _context.AddRangeAsync(roleClaimList);
                await Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
