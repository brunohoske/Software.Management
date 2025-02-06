using SystemManagement.Dao;

namespace SystemManagement.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public Category Category { get; set; }
        public Store Store { get; set; }

        public ProductDao dao = new ProductDao();

        public List<Product> GetProducts()
        {
            return dao.GetProducts(Store); 
        }

    }
}
