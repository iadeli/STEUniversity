using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Official.Domain.Model.Security;
using Official.Domain.Model.Security.ISecurityRepository;
using Official.Persistence.EFCore.Context;
using Official.Persistence.EFCore.Jwt;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Official.Persistence.EFCore.Repositories
{
    public class JwtRepository : IJwtRepository
    {
        private readonly STEDbContext _context;
        public JwtRepository(STEDbContext context)
        {
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

        public async Task<JwtToken> CreateToken(string userName)
        {
            try
            {
                var personId = _context.Users.Where(a => a.UserName == userName).Select(a => a.PersonId).FirstOrDefault();
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, personId.ToString()),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(MvsJwtTokens.Key));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    MvsJwtTokens.Issuer,
                    MvsJwtTokens.Audience,
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: creds
                );

                var results = new JwtToken(); //JwtToken.Instance;

                results.Token = new JwtSecurityTokenHandler().WriteToken(token);
                results.Expiration = token.ValidTo;
                //results.PersonId = personId;
                return results;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<JwtToken> RefreshToken(string token)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(token))
                    return new JwtToken();

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.ReadToken(token);

                if (securityToken.ValidTo < System.DateTime.UtcNow)
                    return new JwtToken();

                var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(MvsJwtTokens.Key));
                TokenValidationParameters validationParameters =
                new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = securityKey
                };
                SecurityToken validatedToken;
                var user = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                if (user.Identity != null && user.Identity.IsAuthenticated)
                    return await CreateToken(user.Identity.Name);

                return new JwtToken();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
