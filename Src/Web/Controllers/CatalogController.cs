using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Services;

namespace Web.Controllers;

public class CatalogController : Controller
{
    private readonly IAuthService _authService;

    public CatalogController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet("catalog")]
    public IActionResult Index()
    {
        return Ok();
    }

    // [HttpPost("new")]
    // public async Task<IActionResult> Register(UserIn dto)
    // {
    //     var response = await _authService.Register(dto);
    //
    //     return View();
    // }
}
