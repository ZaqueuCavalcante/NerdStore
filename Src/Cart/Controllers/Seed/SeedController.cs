using Microsoft.AspNetCore.Mvc;
using NerdStore.Cart.Database;

namespace NerdStore.Cart.Controllers.Seed
{
    [ApiController, Route("[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly CartContext _context;

        public SeedController(
            CartContext context
        ) {
            _context = context;
        }

        [HttpGet]
        public ActionResult SeedDb()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            #region Roles

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
