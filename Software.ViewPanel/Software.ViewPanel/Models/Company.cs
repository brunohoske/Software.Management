namespace Software.ViewPanel.Models
{
    public class Store
    {

        public string Name { get; set; }
        public string cnpj {  get; set; }

        public Store(string name)
        {
            Name = name;
        }

    }
}
