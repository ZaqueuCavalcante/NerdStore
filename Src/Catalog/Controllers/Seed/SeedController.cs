using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalog.Database;
using NerdStore.Catalog.Domain;

namespace NerdStore.Catalog.Controllers.Seed
{
    [ApiController, Route("[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly CatalogContext _context;

        public SeedController(
            CatalogContext context
        ) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> SeedDb()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            #region Roles

            var product00 = new Product
            {
                Name = "Shirt",
                Description = "A simple shirt",
                Active = true,
                Image = "image lalala",
                QuantityInStock = 42,
                RegisteredAt = DateTime.Now
            };

            _context.Add(product00);
            await _context.SaveChangesAsync();

            #endregion
            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            #region Users

            // var samUser = NerdStore.Identity.Domain.User.New("sam@blog.com");

            // await _userManager.CreateAsync(samUser, "Test@123");

            // await _userManager.AddToRolesAsync(samUser, new [] { AdminRole, BloggerRole });

            #endregion
            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            #region Claims

            // await _userManager.AddClaimAsync(elliotUser, new Claim("pinner", "true"));
            // await _userManager.AddClaimAsync(irvingUser, new Claim("liker", "true"));
            // await _userManager.AddClaimAsync(darleneUser, new Claim("liker", "true"));

            #endregion
            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            return Ok("Seed completed!");
        }
    }
}
