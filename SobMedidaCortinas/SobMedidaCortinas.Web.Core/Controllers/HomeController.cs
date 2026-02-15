using Microsoft.AspNetCore.Mvc;
using SobMedidaCortinas.Web.Core.Models;
using SobMedidaCortinas.Web.Core.Services;

namespace SobMedidaCortinas.Web.Core.Controllers;

public class HomeController : Controller
{
    private readonly IProductService _productService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IProductService productService, ILogger<HomeController> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var model = new HomeModel(
            _productService.GetCortinas(),
            _productService.GetPersianas(),
            _productService.GetIdeias()
        );

        return View(model);
    }

    public IActionResult Error()
    {
        return View();
    }
}
