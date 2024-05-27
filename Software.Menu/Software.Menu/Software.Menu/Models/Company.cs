namespace Software.Menu.Models
{
    public class Company
    {

        public string Name { get; set; }
        public string cnpj {  get; set; }

        public Company(string name)
        {
            Name = name;
        }

    }
}
