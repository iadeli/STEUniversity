using Microsoft.AspNetCore.Identity;
using Official.Persistence.EFCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Official.Domain.Model.Person.IUserRepository;
using Official.Persistence.EFCore.Context;

namespace Official.Persistence.EFCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly STEDbContext _context;

        public UserRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, STEDbContext context)
        {
            _userManager = userManager;
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

        public async Task<bool> Register(string userName, string password)
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

        public async Task<bool> Create(string userName, string password, long personId)
        {
            try
            {
                AppUser user = AppUser.Instance;
                user.UserName = userName;
                user.PersonId = personId;
                IdentityResult result = await _userManager.CreateAsync(user, password);
                return result.Succeeded;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> IsExistsUserName(string userName)
        {
            try
            {
                AppUser user = await _userManager.FindByNameAsync(userName);
                return user != null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
