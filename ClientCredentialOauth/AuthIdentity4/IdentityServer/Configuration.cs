using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> GetApis() =>
            new List<ApiScope>{
                new ApiScope("ApiOne"),
            };

        public static IEnumerable<Client> GetClients() =>
                new List<Client>{
                new Client{
                    ClientId="client_id",
                    ClientSecrets={ new Secret("client_secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes =   {"ApiOne"},
                }
                };
    }
}
