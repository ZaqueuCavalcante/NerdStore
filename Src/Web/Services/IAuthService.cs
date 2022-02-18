using Web.Models;

namespace Web.Services
{
    public interface IAuthService
    {
        Task<LoginOut> Login(UserIn dto);

        Task<string> Register(UserIn dto);

        Task<string> Logout();
    }
}
