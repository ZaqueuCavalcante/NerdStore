using System.Text;
using System.Text.Json;
using Web.Models;

namespace Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7064");
            _httpClient = httpClient;
        }

        public async Task<LoginOut> Login(UserIn dto)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(dto),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("/users/login", content);

            return JsonSerializer.Deserialize<LoginOut>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Register(UserIn dto)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(dto),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("/users/new", content);

            return "Ok";
        }

        public Task<string> Logout()
        {
            throw new NotImplementedException();
        }
    }
}
