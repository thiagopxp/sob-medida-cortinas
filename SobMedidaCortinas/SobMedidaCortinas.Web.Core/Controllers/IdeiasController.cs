using Microsoft.AspNetCore.Mvc;
using SobMedidaCortinas.Web.Core.Services;

namespace SobMedidaCortinas.Web.Core.Controllers;

public class IdeiasController : Controller
{
    private readonly IProductService _productService;
    private readonly ILogger<IdeiasController> _logger;

    public IdeiasController(IProductService productService, ILogger<IdeiasController> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    // GET: Ideias
    public IActionResult Index(string? id)
    {
        if (string.IsNullOrEmpty(id))
        {
            // Show all ideias
            var ideias = _productService.GetIdeias();
            return View(ideias);
        }

        var ideia = _productService.GetIdeiaById(id);

        if (ideia == null)
        {
            _logger.LogWarning("Ideia not found: {Id}", id);
            return NotFound();
        }

        return View(ideia);
    }
}
