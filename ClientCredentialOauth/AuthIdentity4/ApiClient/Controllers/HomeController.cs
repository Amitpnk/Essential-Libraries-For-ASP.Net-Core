using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //[Route("/")]
        //public async Task<IActionResult> Index()
        //{
        //    //retrieve access token
        //    var serverClient = _httpClientFactory.CreateClient();

        //    var discoveryDocument = await serverClient.GetDiscoveryDocumentAsync("https://localhost:44342/");

        //    var tokenResponse = await serverClient.RequestClientCredentialsTokenAsync(
        //        new ClientCredentialsTokenRequest
        //        {
        //            Address = discoveryDocument.TokenEndpoint,

        //            ClientId = "client_id",
        //            ClientSecret = "client_secret",

        //            Scope = "ApiOne",
        //        });

        //    //retrieve secret data
        //    var apiClient = _httpClientFactory.CreateClient();

        //    apiClient.SetBearerToken(tokenResponse.AccessToken);

        //    var response = await apiClient.GetAsync("https://localhost:44321/weatherforecast");

        //    var content = await response.Content.ReadAsStringAsync();

        //    return Ok(new
        //    {
        //        access_token = tokenResponse.AccessToken,
        //        message = content,
        //    });
        //}

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            //retrieve access token
            var serverClient = _httpClientFactory.CreateClient();

            var discoveryDocument = await serverClient.GetDiscoveryDocumentAsync("https://localhost:44342/");

            if (discoveryDocument.IsError)
            {
                return Ok(new
                {
                    message =  discoveryDocument.Error.ToString(),
                });
            }

            var tokenResponse = await serverClient.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = discoveryDocument.TokenEndpoint,

                    ClientId = "client_id",
                    ClientSecret = "client_secret",

                    Scope = "ApiOne",
                });

            if (tokenResponse.IsError)
            {
                return Ok(new
                {
                    message = tokenResponse.Error.ToString(),
                });
            }

            //retrieve secret data
            var apiClient = _httpClientFactory.CreateClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiClient.GetAsync("https://localhost:44321/weatherforecast");

            var content = await response.Content.ReadAsStringAsync();

            return Ok(new
            {
                access_token = tokenResponse.AccessToken,
                message = content,
            });
        }
    }
}
