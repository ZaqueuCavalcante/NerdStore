using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using NerdStore.Catalog.Database;

namespace NerdStore.Catalog.Controllers.Products
{
    [ApiController, Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly CatalogContext _context;

        public ProductsController(
            CatalogContext context
        ) {
            _context = context;
        }

        /// <summary>
        /// Return a products.
        /// </summary>
        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult> GetProduct(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product is null)
                return NotFound();
            
            return Ok(product);
        }

        /// <summary>
        /// Return all products.
        /// </summary>
        [HttpGet, AllowAnonymous]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            
            return Ok(products);
        }
    }
}
