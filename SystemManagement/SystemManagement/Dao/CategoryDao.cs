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
                    categories.Add(category);
                }

                return categories;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                
            }
        }
    }
}
