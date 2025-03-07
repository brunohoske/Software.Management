namespace Software.Menu.Models.ViewModels
{
    public class ItemCart
    {
        
        public Product Product { get; set; } = new Product();
        //public Combo Combo { get; set; }
        public int Quantity { get; set; }
        public List<string> Notes { get; set; }
        public string NotesText { get { return String.Join("\n", Notes); } }
        public List<ItemCart> Acompanhamentos {  get; set; }
        public string Cnpj { get; set; }
        public int TableNumber { get; set; }

        public ItemCart() { }
        public ItemCart(Product product, int quantity, int table,string cnpj)
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

        public double GetPrice()
        {
            double total = 0;
            if(Acompanhamentos != null)
            {
                for (int i = 0; i < Quantity; i++)
                {
                    if(Product is Combo combo)
                    {
                        total += (combo.Products.Sum(p => p.Value)) + (Acompanhamentos.Sum(a => (a.Product.Value * a.Quantity)));
                    }
                    total += (Product.Value) + (Acompanhamentos.Sum(a => (a.Product.Value * a.Quantity)));
                }
              
            }
            else
            {
                if (Product is Combo combo)
                {
                    return combo.Products.Sum(p => p.Value) * Quantity;
                }
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
