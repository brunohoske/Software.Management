using MySql.Data.MySqlClient;
using SystemManagement.Data;
using SystemManagement.Models;

namespace SystemManagement.Dao
{
    public class CategoryDao
    {
        private readonly ConnectionFabric _connectionFabric;
        public CategoryDao(ConnectionFabric connectionFabric)
        {
            _connectionFabric = connectionFabric;
        }
        

        public List<Category> GetCategories(Store store)
        {
            List<Category> categories = new List<Category>();
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM CATEGORIES WHERE CNPJ = {store.Cnpj}", conexao);
                while (reader.Read())
                {
                    Category category = new Category();

                    category.Name = reader["Name"].ToString();
                    category.Description = reader["Description"].ToString();
                    category.IdCategory = int.Parse(reader["IdCategory"].ToString());
                    category.Products = GetProductCategories(store.Cnpj, category.IdCategory);
                    category.IsDisplay = Convert.ToInt16(reader["DisplayMainPage"]);
                    categories.Add(category);
                }

                return categories;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Category> GetCategoriesRecommended(int productId, string cnpj)
        {
            List<Category> categories = new List<Category>();
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT C.* FROM products p JOIN products_recommendations pr ON p.IDPRODUCT = pr.IDPRODUCT JOIN categories C ON C.IDCATEGORY = pr.IDCATEGORY WHERE pr.idproduct = {productId} and pr.cnpj = '{cnpj}';", conexao);
                while (reader.Read())
                {
                    Category category = new Category();

                    category.Name = reader["Name"].ToString();
                    category.Description = reader["Description"].ToString();
                    category.IdCategory = int.Parse(reader["IdCategory"].ToString());
                    category.Products = GetProductCategories(cnpj, category.IdCategory);
                    category.IsDisplay = Convert.ToInt16(reader["DisplayMainPage"]);
                    categories.Add(category);
                }

                return categories;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Product> GetProductCategories(string cnpj, int id)
        {
            List<Product> products = new List<Product>();
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT p.* FROM  products_categories pc JOIN products p ON pc.PRODUCT = p.IDPRODUCT JOIN categories c ON pc.CATEGORY = c.IDCATEGORY WHERE c.idcategory = {id} AND p.CNPJ = '{cnpj}';", conexao);
                while (reader.Read())
                {
                    Product product = new Product();

                    product.Id = reader.GetInt32("IdProduct");
                    product.Name = reader["Product_name"].ToString();
                    product.Value = Convert.ToInt32(reader["PRICE"]);
                    product.Description = reader["DESCRIPTION"].ToString();
                    product.Category = new Category() { IdCategory = int.Parse(reader["IdCategory"].ToString()) };
                    product.Store = new Store() { Name = "McDonalds", Cnpj = reader["CNPJ"].ToString() };
                    product.Kcal = Convert.ToDouble(reader["KCAL"]);
                    product.Image = reader["IMAGE"].ToString();
                    products.Add(product);
                }

                return products;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


       
    }
}
