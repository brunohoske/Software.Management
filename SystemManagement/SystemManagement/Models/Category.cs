using SystemManagement.Dao;

namespace SystemManagement.Models
{
    public class Category
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Store Store { get; set; }
    }
}
