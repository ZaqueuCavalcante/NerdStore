using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using NerdStore.Identity.Managers;
using NerdStore.Identity.Extensions;

namespace NerdStore.Identity.Controllers.Users
{
    [ApiController, Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly TokenManager _tokenManager;
        private IConfiguration _configuration;

        public UsersController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            TokenManager tokenManager,
            IConfiguration configuration
        ) {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenManager = tokenManager;
            _configuration = configuration;
        }

        /// <summary>
        /// Register a new user.
        /// </summary>
        [HttpPost("new"), AllowAnonymous]
        public async Task<IActionResult> RegisterNewUser(UserIn dto)
        {
            var user = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Created("", "User registered!");
        }

        /// <summary>
        /// Login into app.
        /// </summary>
        [HttpPost("login"), AllowAnonymous]
        public async Task<ActionResult> Login(UserIn dto)
        {
            var result = await _signInManager.PasswordSignInAsync(
                userName: dto.Email,
                password: dto.Password,
                isPersistent: false,
                lockoutOnFailure: true
            );

            if (result.Succeeded)
            {
                var accessToken = await _tokenManager.GenerateAccessToken(dto.Email);

                var response =  new LoginOut
                {
                    AccessToken = accessToken,
                    TokenType = "Bearer",
                    ExpiresInMinutes = _configuration["Jwt:ExpirationTimeInMinutes"],
                    Scope = "create"
                };

                return Ok(response);
            }

            if (result.IsLockedOut)
                return BadRequest("Account locked.");

            if (result.IsNotAllowed)
                return BadRequest("Login not allowed.");

            if (result.RequiresTwoFactor)
                return BadRequest("Requires two factor.");
            
            return BadRequest("Login failed.");
        }

        /// <summary>
        /// Logout of the app.
        /// </summary>
        [HttpPost("logout"), Authorize]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok("Logout succeeded.");
        }

        /// <summary>
        /// Change user password.
        /// </summary>
        [HttpPatch("change-password"), Authorize]
        public async Task<ActionResult> ChangePassword(ChangePasswordIn dto)
        {
            var userId = User.GetId();

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            var result = await _userManager.ChangePasswordAsync(
                user,
                dto.Current,
                dto.NewPassword
            );

            if (result.Succeeded)
                return Ok("Password changed.");

            return BadRequest("Password not changed.");
        }
    }
}
