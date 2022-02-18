using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NerdStore.Cart.Database;
using Microsoft.EntityFrameworkCore;

namespace NerdStore.Cart.Controllers.Products
{
    [ApiController, Route("[controller]")]
    [Authorize]
    public class CartsController : ControllerBase
    {
        private readonly CartContext _context;

        public CartsController(
            CartContext context
        ) {
            _context = context;
        }

        /// <summary>
        /// Get a client cart.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetClientCart()
        {
            var cart = await _context.ClientCarts.FirstOrDefaultAsync();

            return Ok(cart);
        }
    }
}
