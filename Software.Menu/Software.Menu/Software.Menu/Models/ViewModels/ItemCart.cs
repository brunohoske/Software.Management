namespace Software.Menu.Models.ViewModels
{
    public class ItemCart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public List<string> Notes { get; set; }
        public List<Product> Acompanhamentos {  get; set; }
        public Company Store { get; set; }
        public Table Table { get; set; }

        public string GetNote()
        {
            string notes = "";
            foreach (var note in Notes)
            {
                notes += note + "\n";
            }
            return notes;
        }
    }
}
