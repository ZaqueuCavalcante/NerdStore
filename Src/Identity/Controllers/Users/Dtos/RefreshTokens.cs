using System.ComponentModel.DataAnnotations;

namespace NerdStore.Identity.Controllers.Users
{
    public class RefreshTokenIn
    {
        [Required]
        public string AccessToken { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }

    public class RefreshTokenOut
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}