using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SobMedidaCortinas.Web.Models
{
    public class ProductModel
    {
        public ProductModel(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    };
}