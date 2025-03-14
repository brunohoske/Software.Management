namespace Software.Menu.Models.ViewModels
{
    public class ItemCart
    {
        
        public ProductCartModel Product { get; set; }
        public int Quantity { get; set; }
        public List<string> Notes { get; set; }
        public string NotesText { get { return String.Join("\n", Notes); } }
        public List<ItemCart> Acompanhamentos {  get; set; }
        public string Cnpj { get; set; }
        public int TableNumber { get; set; }

        public ItemCart() { }
        public ItemCart(ProductCartModel product, int quantity, int table,string cnpj)
        {
            Product = product;
            Quantity = quantity;
            Cnpj = cnpj;
            TableNumber = table;
        }

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

        public decimal GetPrice()
        {
            decimal total = 0;
            if(Acompanhamentos != null)
            {
                for (int i = 0; i < Quantity; i++)
                {
                    if(Product.IsCombo == true)
                    {
                        total += (Product.ComboProducts.Sum(p => p.Price)) + (Acompanhamentos.Sum(a => (a.Product.Price * a.Quantity)));
                    }
                    total += (Product.Price) + (Acompanhamentos.Sum(a => (a.Product.Price * a.Quantity)));
                }
              
            }
            else
            {
                if (Product.IsCombo)
                {
                    return Product.ComboProducts.Sum(p => p.Price) * Quantity;
                }
                return Product.Price * Quantity;
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
