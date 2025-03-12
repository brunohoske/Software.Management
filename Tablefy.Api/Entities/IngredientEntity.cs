﻿namespace Tablefy.Api.Entities
{
    public class IngredientEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }

        public ICollection<ProductIngredientsEntity> ProductIngredients { get; set; } = new List<ProductIngredientsEntity>();
    }
}