﻿namespace Software.Menu.Models
{
    public class Combo : Product
    {
        
        public List<Product> Products { get; set; }
        public List<Grupo> Groups { get; set; }

        public Combo()
        {
            Ingredients = new List<Ingredient>();
        }
    }
}
