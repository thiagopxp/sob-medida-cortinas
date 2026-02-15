using Microsoft.AspNetCore.Mvc;
using SobMedidaCortinas.Web.Core.Services;

namespace SobMedidaCortinas.Web.Core.Controllers;

public class CortinasController : Controller
{
    private readonly IProductService _productService;
    private readonly ILogger<CortinasController> _logger;

    public CortinasController(IProductService productService, ILogger<CortinasController> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    // GET: Cortinas
    public IActionResult Index(string? id)
    {
        if (string.IsNullOrEmpty(id))
        {
            // Show all cortinas
            var cortinas = _productService.GetCortinas();
            return View(cortinas);
        }

        var cortina = _productService.GetCortinaById(id);

        if (cortina == null)
        {
            _logger.LogWarning("Cortina not found: {Id}", id);
            return NotFound();
        }

        return View(cortina);
    }
}
