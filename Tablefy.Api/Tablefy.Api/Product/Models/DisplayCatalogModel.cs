﻿namespace Tablefy.Api.Product.Models
{
    public class DisplayCatalogModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductSimpleModel> Products { get; set; }
    }
}
