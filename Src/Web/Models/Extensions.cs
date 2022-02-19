using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Web.Models;

public static class HttpExtensions
{
    public static StringContent ToJson(this object dto)
    {
        return new StringContent(
            JsonSerializer.Serialize(dto),
            Encoding.UTF8,
            "application/json"
        );
    }  
}

public interface IWebUser
{
    string Name { get; }
    Guid GetId();
    string GetEmail();
    string GetToken();
    bool IsAuthenticated();
    bool IsInRole(string role);
    IEnumerable<Claim> GetClaims();
    HttpContext GetHttpContext();
}

public class WebUser : IWebUser
{
    private readonly IHttpContextAccessor _accessor;

    public WebUser(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public string Name => _accessor.HttpContext.User.Identity.Name;

    public Guid GetId()
    {
        return IsAuthenticated() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.Empty;
    }

    public string GetEmail()
    {
        return IsAuthenticated() ? _accessor.HttpContext.User.GetUserEmail() : "";
    }

    public string GetToken()
    {
        return IsAuthenticated() ? _accessor.HttpContext.User.GetUserToken() : "";
    }

    public bool IsAuthenticated()
    {
        return _accessor.HttpContext.User.Identity.IsAuthenticated;
    }

    public bool IsInRole(string role)
    {
        return _accessor.HttpContext.User.IsInRole(role);
    }

    public IEnumerable<Claim> GetClaims()
    {
        return _accessor.HttpContext.User.Claims;
    }

    public HttpContext GetHttpContext()
    {
        return _accessor.HttpContext;
    }
}

public static class ClaimsPrincipalExtensions
{
    public static string GetUserId(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentException(nameof(principal));
        }

        var claim = principal.FindFirst("sub");
        return claim?.Value;
    }

    public static string GetUserEmail(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentException(nameof(principal));
        }

        var claim = principal.FindFirst("email");
        return claim?.Value;
    }

    public static string GetUserToken(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentException(nameof(principal));
        }

        var claim = principal.FindFirst("JWT");
        return claim?.Value;
    }
}
