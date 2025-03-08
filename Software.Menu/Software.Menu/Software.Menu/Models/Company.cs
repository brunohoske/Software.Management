namespace Software.Menu.Models
{
    public class Company
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Cnpj {  get; set; }
        public string Image { get; set; }
        public string Banner { get; set; }


        public Company() { }
        public Company(string name)
        {
            Name = name;
        }

    }
}
