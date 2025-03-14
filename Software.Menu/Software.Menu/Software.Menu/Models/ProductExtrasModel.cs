﻿namespace Software.Menu.Models
{
    public class ProductExtrasModel
    {
        public ICollection<ProductSimpleModel> Recommendations { get; set; } = new List<ProductSimpleModel>();
        public ICollection<ProductSideModel> Sides { get; set; } = new List<ProductSideModel>();
        public List<ProductSimpleModel> ComboProducts { get; set; } = new List<ProductSimpleModel>();
        public ICollection<IngredientModel> Ingredients { get; set; } = new List<IngredientModel>();
        public ICollection<SelectionGroupModel> SelectionGroups { get; set; } = new List<SelectionGroupModel>();
    }
}
