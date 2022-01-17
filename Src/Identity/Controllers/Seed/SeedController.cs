﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Identity.Database;
using NerdStore.Identity.Domain;

namespace NerdStore.Identity.Controllers.Seed
{
    [ApiController, Route("[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly IdentityContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public SeedController(
            IdentityContext context,
            UserManager<User> userManager,
            RoleManager<Role> roleManager
        ) {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<ActionResult> SeedDb()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            #region Roles

            // var readerRole = new Role { Name = ReaderRole };
            // var bloggerRole = new Role { Name = BloggerRole };
            // var adminRole = new Role { Name = AdminRole };

            // await _roleManager.CreateAsync(readerRole);
            // await _roleManager.CreateAsync(bloggerRole);
            // await _roleManager.CreateAsync(adminRole);

            #endregion
            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            #region Users

            var samUser = NerdStore.Identity.Domain.User.New("sam@blog.com");

            await _userManager.CreateAsync(samUser, "Test@123");

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
