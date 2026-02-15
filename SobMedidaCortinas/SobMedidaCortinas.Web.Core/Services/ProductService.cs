using Newtonsoft.Json;
using SobMedidaCortinas.Web.Core.Models;

namespace SobMedidaCortinas.Web.Core.Services;

public class ProductService : IProductService
{
    private readonly List<ProductModel> _cortinas;
    private readonly List<ProductModel> _persianas;
    private readonly List<ProductModel> _ideias;
    private readonly ILogger<ProductService> _logger;

    public ProductService(IWebHostEnvironment environment, ILogger<ProductService> logger)
    {
        _logger = logger;

        try
        {
            var dataPath = Path.Combine(environment.ContentRootPath, "Data");

            _cortinas = LoadProductsFromFile(Path.Combine(dataPath, "cortinas.json"));
            _persianas = LoadProductsFromFile(Path.Combine(dataPath, "persianas.json"));
            _ideias = LoadProductsFromFile(Path.Combine(dataPath, "ideias.json"));

            _logger.LogInformation("Loaded {CortinasCount} cortinas, {PersianasCount} persianas, {IdeiasCount} ideias",
                _cortinas.Count, _persianas.Count, _ideias.Count);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading product data");
            _cortinas = new List<ProductModel>();
            _persianas = new List<ProductModel>();
            _ideias = new List<ProductModel>();
        }
    }

    private List<ProductModel> LoadProductsFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            _logger.LogWarning("Product file not found: {FilePath}", filePath);
            return new List<ProductModel>();
        }

        var json = File.ReadAllText(filePath);
        var products = JsonConvert.DeserializeObject<List<ProductModel>>(json);
        return products ?? new List<ProductModel>();
    }

    public List<ProductModel> GetCortinas() => _cortinas;

    public List<ProductModel> GetPersianas() => _persianas;

    public List<ProductModel> GetIdeias() => _ideias;

    public ProductModel? GetCortinaById(string id) =>
        _cortinas.FirstOrDefault(c => c.Id == id);

    public ProductModel? GetPersianaById(string id) =>
        _persianas.FirstOrDefault(p => p.Id == id);

    public ProductModel? GetIdeiaById(string id) =>
        _ideias.FirstOrDefault(i => i.Id == id);
}
