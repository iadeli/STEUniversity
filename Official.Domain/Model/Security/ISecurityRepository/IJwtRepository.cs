using System.Threading.Tasks;

namespace Official.Domain.Model.Security.ISecurityRepository
{
    public interface IJwtRepository
    {
        Task<JwtToken> CreateToken(string userName);
        Task<JwtToken> RefreshToken(string token);
    }
}
