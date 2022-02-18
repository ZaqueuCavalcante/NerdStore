using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class UserIn
{
    /// <example>sam@blog.com</example>
    [Required, EmailAddress]
    public string Email { get; set; }

    /// <example>Test@123</example>
    [Required]
    public string Password { get; set; }
}

public class LoginOut
{
    public string AccessToken { get; set; }
    public string TokenType { get; set; }
    public string ExpiresInMinutes { get; set; }
    public string Scope { get; set; }        
}
