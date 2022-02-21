using Web.Models;

namespace Web.Services
{
    public interface ICatalogService
    {
        Task<List<ProductOut>> GetProducts();

        Task<ProductOut> GetProduct(Guid id);
    }
}
