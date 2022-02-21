using Microsoft.AspNetCore.Mvc;
using Web.Services;

namespace Web.Controllers;

public class CatalogController : Controller
{
    private readonly ICatalogService _catalogService;

    public CatalogController(ICatalogService catalogService)
    {
        _catalogService = catalogService;
    }

    [HttpGet("catalog")]
    public async Task<IActionResult> Products()
    {
        var products = await _catalogService.GetProducts();
        return View(products);
    }

    [HttpGet("catalog/{id}")]
    public async Task<IActionResult> Product(Guid id)
    {
        var product = await _catalogService.GetProduct(id);

        return View(product);
    }
}
