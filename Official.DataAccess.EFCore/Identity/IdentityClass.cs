using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Official.Persistence.EFCore.Context;

namespace Official.Persistence.EFCore.Identity
{
    public class AppUserRole : IdentityUserRole<long>
    {
    }

    public class AppRoleClaim : IdentityRoleClaim<long>
    {
    }

    public class AppUserClaim : IdentityUserClaim<long>
    {
    }

    public class AppUserLogin : IdentityUserLogin<long>
    {
    }

    public class AppUserToken : IdentityUserToken<long>
    {
    }



    public class ApplicationRoleManager : RoleManager<AppRole>
    {
        public ApplicationRoleManager(IRoleStore<AppRole> store, IEnumerable<IRoleValidator<AppRole>> roleValidators,
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<AppRole>> logger) :
            base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }

    public class ApplicationRoleStore : RoleStore<AppRole, STEDbContext, long, AppUserRole, AppRoleClaim>
    {
        public ApplicationRoleStore(STEDbContext context, IdentityErrorDescriber describer = null) : base(context,
            describer)
        {
        }

        protected override AppRoleClaim CreateRoleClaim(AppRole role, Claim claim)
        {
            return new AppRoleClaim()
            {
                RoleId = role.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            };
        }
    }

    public class ApplicationSignInManager : SignInManager<AppUser>
    {
        public ApplicationSignInManager(UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<AppUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<AppUser>> logger, IAuthenticationSchemeProvider schemes) : base(userManager,
            contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
        }
    }

    public class ApplicationUserManager : UserManager<AppUser>
    {
        public ApplicationUserManager(IUserStore<AppUser> store, IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<AppUser> passwordHasher, IEnumerable<IUserValidator<AppUser>> userValidators,
            IEnumerable<IPasswordValidator<AppUser>> passwordValidators, ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<AppUser>> logger) : base(
            store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services,
            logger)
        {
        }
    }

    public class ApplicationUserStore : UserStore<AppUser, AppRole, STEDbContext, long, AppUserClaim, AppUserRole,
        AppUserLogin, AppUserToken, AppRoleClaim>
    {
        public ApplicationUserStore(STEDbContext context, IdentityErrorDescriber describer = null) : base(context,
            describer)
        {
        }

        protected override AppUserClaim CreateUserClaim(AppUser user, Claim claim)
        {
            var userClaim = new AppUserClaim {UserId = user.Id};
            userClaim.InitializeFromClaim(claim);
            return userClaim;
        }

        protected override AppUserLogin CreateUserLogin(AppUser user, UserLoginInfo login)
        {
            return new AppUserLogin()
            {
                UserId = user.Id,
                ProviderKey = login.ProviderKey,
                LoginProvider = login.LoginProvider,
                ProviderDisplayName = login.ProviderDisplayName
            };
        }

        protected override AppUserRole CreateUserRole(AppUser user, AppRole role)
        {
            return new AppUserRole()
            {
                UserId = user.Id,
                RoleId = role.Id
            };
        }

        protected override AppUserToken CreateUserToken(AppUser user, string loginProvider, string name, string value)
        {
            return new AppUserToken
            {
                UserId = user.Id,
                LoginProvider = loginProvider,
                Name = name,
                Value = value
            };
        }
    }
}