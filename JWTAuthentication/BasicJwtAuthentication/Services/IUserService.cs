using BasicJwtAuthentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicJwtAuthentication.Services
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterModel model);
      
        Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model);

        Task<string> AddRoleAsync(AddRoleModel model);
    }
}
