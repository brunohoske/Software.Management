namespace SystemManagement.Models
{
    public class Grupo
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string ViewName { get; set; }
        public string Description { get; set; }
        public Store Store { get; set; }
        public List<Product> Products { get; set; }
        public List<Combo> Combos { get; set; }

    }
}
