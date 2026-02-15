namespace SobMedidaCortinas.Web.Core.Models;

public class HomeModel
{
    public HomeModel()
    {
        Cortinas = new List<ProductModel>();
        Persianas = new List<ProductModel>();
        Ideias = new List<ProductModel>();
    }

    public HomeModel(List<ProductModel> cortinas, List<ProductModel> persianas, List<ProductModel> ideias)
    {
        Cortinas = cortinas;
        Persianas = persianas;
        Ideias = ideias;
    }

    public List<ProductModel> Cortinas { get; set; }
    public List<ProductModel> Persianas { get; set; }
    public List<ProductModel> Ideias { get; set; }
}
