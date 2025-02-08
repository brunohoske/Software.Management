namespace Software.Menu.Models
{
    public class Ingredient
    {
        public int IdIngredient { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cnpj { get; set; }

        public Ingredient()
        {
        }

        public Ingredient(int idIngredient, string name, string description, string cnpj)
        {
            IdIngredient = idIngredient;
            Name = name;
            Description = description;
            Cnpj = cnpj;
        }
    }
}
