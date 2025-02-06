using MySql.Data.MySqlClient;
using SystemManagement.Data;
using SystemManagement.Models;

namespace SystemManagement.Dao
{
    public class ProductDao : BaseDao
    {
        MySqlConnection conexao = null;
        ConnectionFabric f = new ConnectionFabric();
        public List<Product> GetProducts(Store s)
        {
            List<Product> products = new List<Product>();
            try
            {
                using var reader = f.ExecuteCommandReader($"SELECT * FROM PRODUCTS WHERE CNPJ = {s.Cnpj}");
                while (reader.Read())
                {
                    Product p = new Product();

                    p.Id = reader.GetInt32("IdProduct");
                    p.Name = reader["Product_name"].ToString();
                    p.Value = Convert.ToInt32(reader["PRICE"]);
                    p.Description = reader["DESCRIPTION"].ToString();
                    p.Category = new Category() { IdCategory = int.Parse(reader["IdCategory"].ToString()) };
                    p.Store = new Store() { Name = "McDonalds", Cnpj = reader["CNPJ"].ToString() };


                    products.Add(p);
                }

                return products;
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
        public Product GetProductFromId(int id)
        {
            try
            {
                using var reader = f.ExecuteCommandReader($"SELECT * FROM PRODUCTS WHERE IDPRODUCT = {id}");
                Product p = new Product();
                while (reader.Read())
                {
                    p.Id = Convert.ToInt32(reader["idproduct"].ToString());
                    p.Name = reader["Product_Name"].ToString();
                    p.Value = Convert.ToInt32(reader["price"]);
                    p.Description = reader["description"].ToString();
                    p.Store = new Store() { Cnpj = reader["cnpj"].ToString() };

                }

                return p;
            }
            catch
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
