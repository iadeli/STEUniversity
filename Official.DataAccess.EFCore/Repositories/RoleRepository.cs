using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Official.Domain.Model;
using Official.Domain.Model.Security.IRoleRepository;
using Official.Persistence.EFCore.Context;
using Official.Persistence.EFCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Official.Persistence.EFCore.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly STEDbContext _context;
        private IDbContextTransaction _tran;

        public RoleRepository(STEDbContext context, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
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

        public async Task<long> Create(string name)
        {
            try
            {
                AppRole role = new AppRole()
                {
                    Name = name
                };
                IdentityResult result = await _roleManager.CreateAsync(role);
                if (!result.Succeeded)
                    return 0;
                return role.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> CreateUserRole(long roleId, List<long> userIds)
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

        public async Task<bool> IsExistsRoleAsync(long id, string name)
        {
            try
            {
                AppRole role = await _roleManager.FindByNameAsync(name);
                if (id != 0)
                    role = _context.Roles.Where(a => a.Id != id && a.Name == name).FirstOrDefault();
                return role != null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> RemoveUserRole(long roleId)
        {
            try
            {
                var userRoles = _context.UserRoles.Where(a => a.RoleId == roleId).ToList();
                _context.RemoveRange(userRoles);
                return await Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<long> UpdateAsync(long id, string name)
        {
            try
            {
                AppRole role = await _roleManager.FindByIdAsync(id.ToString());
                role.Name = name;
                //_context.Entry<AppRole>(role).State = EntityState.Modified;
                //_context.Update<AppRole>(role);
                await Save();
                return role.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Remove(long id)
        {
            try
            {
                var role = _context.Roles.Where(a => a.Id == id).ToList();
                _context.RemoveRange(role);
                return await Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
