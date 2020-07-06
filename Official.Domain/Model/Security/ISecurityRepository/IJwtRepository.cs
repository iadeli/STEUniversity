using Official.Domain.Model.Security.ISecurityRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Domain.Model.Security
{
    public interface IJwtRepository
    {
        Task<JwtToken> CreateToken(string userName);
    }
}
