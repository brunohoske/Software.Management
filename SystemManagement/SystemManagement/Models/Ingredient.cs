namespace SystemManagement.Models
{
    public class Ingredient
    {
        public int IdIngredient { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Store Store {  get; set; }

        public Ingredient(){}

        public Ingredient(int idIngredient, string name, string description, Store store)
        {
            IdIngredient = idIngredient;
            Name = name;
            Description = description;
            Store = store;
        }
    }
}
