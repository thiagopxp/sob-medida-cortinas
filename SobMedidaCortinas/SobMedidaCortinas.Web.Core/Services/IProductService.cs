using SobMedidaCortinas.Web.Core.Models;

namespace SobMedidaCortinas.Web.Core.Services;

public interface IProductService
{
    List<ProductModel> GetCortinas();
    List<ProductModel> GetPersianas();
    List<ProductModel> GetIdeias();
    ProductModel? GetCortinaById(string id);
    ProductModel? GetPersianaById(string id);
    ProductModel? GetIdeiaById(string id);
}
