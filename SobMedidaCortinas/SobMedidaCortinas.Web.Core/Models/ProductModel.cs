namespace SobMedidaCortinas.Web.Core.Models;

public class ProductModel
{
    public ProductModel()
    {
        Id = string.Empty;
        Name = string.Empty;
        Description = string.Empty;
    }

    public ProductModel(string id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
