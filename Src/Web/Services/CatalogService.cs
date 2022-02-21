using System.Text.Json;
using Web.Models;

namespace Web.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7153");
            _httpClient = httpClient;
        }

        public async Task<List<ProductOut>> GetProducts()
        {
            var response = await _httpClient.GetAsync("/products");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            return JsonSerializer.Deserialize<List<ProductOut>>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<ProductOut> GetProduct(Guid id)
        {
            var response = await _httpClient.GetAsync($"/products/{id}");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            return JsonSerializer.Deserialize<ProductOut>(await response.Content.ReadAsStringAsync(), options);
        }
    }
}
