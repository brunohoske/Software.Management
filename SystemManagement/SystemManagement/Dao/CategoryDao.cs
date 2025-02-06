using MySql.Data.MySqlClient;
using SystemManagement.Data;
using SystemManagement.Models;

namespace SystemManagement.Dao
{
    public class CategoryDao
    {
        MySqlConnection conexao = null;
        ConnectionFabric f = new ConnectionFabric();

        public List<Category> GetCategories(Store store)
        {
            List<Category> categories = new List<Category>();
            try
            {
                using var reader = f.ExecuteCommandReader($"SELECT * FROM CATEGORIES WHERE CNPJ = {store.Cnpj}");
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
                f.CloseConnection();
            }
        }
    }
}
