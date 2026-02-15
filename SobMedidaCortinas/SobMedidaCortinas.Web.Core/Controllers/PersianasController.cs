using Microsoft.AspNetCore.Mvc;
using SobMedidaCortinas.Web.Core.Services;

namespace SobMedidaCortinas.Web.Core.Controllers;

public class PersianasController : Controller
{
    private readonly IProductService _productService;
    private readonly ILogger<PersianasController> _logger;

    public PersianasController(IProductService productService, ILogger<PersianasController> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    // GET: Persianas
    public IActionResult Index(string? id)
    {
        if (string.IsNullOrEmpty(id))
        {
            // Show all persianas
            var persianas = _productService.GetPersianas();
            return View(persianas);
        }

        var persiana = _productService.GetPersianaById(id);

        if (persiana == null)
        {
            _logger.LogWarning("Persiana not found: {Id}", id);
            return NotFound();
        }

        return View(persiana);
    }
}
