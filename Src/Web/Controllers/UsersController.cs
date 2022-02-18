using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Services;

namespace Web.Controllers;

public class UsersController : Controller
{
    private readonly IAuthService _authService;

    public UsersController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet("new")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost("new")]
    public async Task<IActionResult> Register(UserIn dto)
    {
        var response = await _authService.Register(dto);

        return View();
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserIn dto)
    {
        var response = await _authService.Login(dto);

        return View();
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var response = await _authService.Logout();

        return View();
    }
}
