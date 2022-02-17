using Microsoft.AspNetCore.Identity;

namespace NerdStore.Identity.Domain
{
    public class User : IdentityUser
    {
        public List<RefreshToken> RefreshTokens { get; set; }

        public static User New(string email)
        {
            return new User
            {
                UserName = email,
                Email = email
            };
        }
    }
}
