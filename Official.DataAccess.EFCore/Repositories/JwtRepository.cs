using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Official.Domain.Model.Security;
using Official.Domain.Model.Security.ISecurityRepository;
using Official.Persistence.EFCore.Jwt;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Official.Persistence.EFCore.Repositories
{
    public class JwtRepository : IJwtRepository
    {
        public async Task<JwtToken> CreateToken(string userName)
        {
            try
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, userName)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(MvsJwtTokens.Key));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    MvsJwtTokens.Issuer,
                    MvsJwtTokens.Audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                var results = new JwtToken(); //JwtToken.Instance;

                results.Token = new JwtSecurityTokenHandler().WriteToken(token);
                results.Expiration = token.ValidTo;

                return results;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
