using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace NerdStore.Identity.Managers
{
    public class TokenManager
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IConfiguration _configuration;

        public TokenManager(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration
        ) {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<string> GenerateAccessToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));

            var roleNames = await _userManager.GetRolesAsync(user);
            foreach (var role in roleNames)
            {
                claims.Add(new Claim("role", role));
            }

            var roles = await _roleManager.Roles.Where(r => roleNames.Contains(r.Name)).ToListAsync();
            if (roles != null && roles.Any())
            {
                foreach (var role in roles)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    if (roleClaims != null && roleClaims.Any())
                        claims.AddRange(roleClaims);
                }
            }

            var userClaims = await _userManager.GetClaimsAsync(user);
            if (userClaims != null && userClaims.Any())
                claims.AddRange(userClaims);

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecurityKey"]);
            var expirationTime = double.Parse(_configuration["Jwt:ExpirationTimeInMinutes"]);
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                Expires = DateTime.UtcNow.AddMinutes(expirationTime),
                SigningCredentials = signingCredentials,
                Subject = identityClaims
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
