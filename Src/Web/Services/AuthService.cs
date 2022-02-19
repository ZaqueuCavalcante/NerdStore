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
            var response = await _httpClient.PostAsync("/users/login", dto.ToJson());

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            return JsonSerializer.Deserialize<LoginOut>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<string> Register(UserIn dto)
        {
            var response = await _httpClient.PostAsync("/users/new", dto.ToJson());

            return "Ok";
        }

        public Task<string> Logout()
        {
            throw new NotImplementedException();
        }
    }
}
