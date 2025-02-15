﻿namespace Software.Menu.Models.ViewModels
{
    public class ItemCart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public List<string> Notes { get; set; }
        public List<ItemCart> Acompanhamentos {  get; set; }
        public Company Store { get; set; }
        public Table Table { get; set; }

        public string GetNote()
        {
            string notes = "";
            if(Notes != null)
                foreach (var note in Notes)
                {
                    notes += note + "\n";
                }
            return notes;
        }

        public double GetPrice()
        {
            double total = 0;
            if(Acompanhamentos != null)
            {
                for (int i = 0; i < Quantity; i++)
                {
                    total += (Product.Value) + (Acompanhamentos.Sum(a => (a.Product.Value * a.Quantity)));
                }
              
            }
            else
            {
                return Product.Value * Quantity;
            }
            return total;
        }
        public async Task IncrementQuantity()
        {
            Quantity++;
        }
        public async Task DecrementQuantity()
        {
            Quantity--;
        }
    }
}
