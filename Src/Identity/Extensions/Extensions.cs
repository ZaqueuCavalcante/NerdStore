using System.Security.Claims;

namespace NerdStore.Identity.Extensions
{
    public static class Extensions
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue("sub");
        }
    }
}
