using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using Official.Domain.Model.Security;
using Official.Domain.Model.Security.IUserRepository;
using Official.Persistence.EFCore.Context;
using Official.Persistence.EFCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Official.Persistence.EFCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly STEDbContext _context;
        private IDbContextTransaction _tran;

        public UserRepository(UserManager<AppUser> userManager, STEDbContext context)
        {
            _userManager = userManager;
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

        public bool IsExistsUserName(AppUserTransfer appUserTransfer)
        {
            try
            {
                var isExists = _context.AspNetUsers.Where(a => a.UserName == appUserTransfer.UserName).Any();
                if (appUserTransfer.Id != 0)
                    isExists = _context.AspNetUsers.Where(a => a.Id != appUserTransfer.Id && a.UserName == appUserTransfer.UserName).Any();
                return isExists;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool IsExistsPerson(AppUserTransfer appUserTransfer)
        {
            try
            {
                var isExists = _context.AspNetUsers.Where(a => a.PersonId == appUserTransfer.PersonId).Any();
                if (appUserTransfer.Id != 0)
                    isExists = _context.AspNetUsers.Where(a => a.Id != appUserTransfer.Id && a.PersonId == appUserTransfer.PersonId).Any();
                return isExists;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Create(AppUserTransfer appUserTransfer)
        {
            try
            {
                AppUser user = new AppUser()
                {
                    UserName = appUserTransfer.UserName,
                    PersonId = appUserTransfer.PersonId
                };
                IdentityResult result = await _userManager.CreateAsync(user, appUserTransfer.Password);
                return result.Succeeded;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<long> GetUserIdByUserName(string userName)
        {
            try
            {
                AppUser user = await _userManager.FindByNameAsync(userName);
                return user.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> CreateUserRole(long userId, List<long> roleIds)
        {
            try
            {
                var userRoleList = new List<AppUserRole>();
                foreach (var roleId in roleIds)
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

        public AppUserTransfer GetUserById(long userId)
        {
            try
            {
                var user = _context.AspNetUsers.Where(a => a.Id == userId).FirstOrDefault();
                var appUserTransfer = new AppUserTransfer()
                {
                    Id = user.Id,
                    PersonId = user.PersonId,
                    UserName = user.UserName
                };
                return appUserTransfer;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<long> Update(AppUserTransfer appUserTransfer)
        {
            try
            {
                var user = _context.AspNetUsers.Where(a => a.Id == appUserTransfer.Id).FirstOrDefault();
                user.UserName = appUserTransfer.UserName;
                await Save();
                return user.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> RemoveUserRole(long userId)
        {
            try
            {
                var userRoleIds = _context.AspNetUserRoles.Where(a => a.UserId == userId).ToList();
                _context.RemoveRange(userRoleIds);
                return await Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> UpdateUserRoleAsync(long userId, List<long> roleIds)
        {
            var userRoleList = new List<AppUserRole>();
            foreach (var roleId in roleIds)
            {
                var userRole = new AppUserRole()
                {
                    UserId = userId,
                    RoleId = roleId
                };
                userRoleList.Add(userRole);
            }
            await _context.AddRangeAsync(userRoleList);
            return await Save();
        }

        public async Task<int> Remove(long id)
        {
            var user = _context.AspNetUsers.Where(a => a.Id == id).FirstOrDefault();
            _context.Remove(user);
            return await Save();
        }        
    }
}
