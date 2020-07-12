using RefreshJwtAuthentication.Model;
using System.Threading.Tasks;

namespace RefreshJwtAuthentication.Services
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterModel model);

        Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model);

        Task<string> AddRoleAsync(AddRoleModel model);
        Task<AuthenticationModel> RefreshTokenAsync(string refreshToken);

        ApplicationUser GetById(string id);
        bool RevokeToken(string token);
    }
}
