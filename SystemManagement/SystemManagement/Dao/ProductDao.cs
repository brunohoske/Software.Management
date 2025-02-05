using MySql.Data.MySqlClient;
using SystemManagement.Data;
using SystemManagement.Models;

namespace SystemManagement.Dao
{
    public class ProductDao : BaseDao
    {
        MySqlConnection conexao = null;
        ConnectionFabric fabric = new ConnectionFabric();
        public List<Product> GetProducts(Store s)
        {
            List<Product> products = new List<Product>();
            try
            {
                using var reader = fabric.ExecuteCommandReader($"SELECT * FROM PRODUCTS WHERE CNPJ = {s.Cnpj}");
                while (reader.Read())
                {
                    Product p = new Product();

                    p.Id = reader.GetInt32("IdProduct");
                    p.Name = reader["Product_name"].ToString();
                    p.Value = Convert.ToInt32(reader["PRICE"]);
                    p.Description = reader["DESCRIPTION"].ToString();
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
                fabric.CloseConnection();
            }
        }
        public Product GetProductFromId(int id)
        {
            try
            {
                using var reader = f.ExecuteCommandReader($"SELECT * FROM PRODUCTS WHERE IDPRODUCT = {id}");
                Product product = new Product();
                while (reader.Read())
                {
                    product.Id = Convert.ToInt32(reader["idproduct"].ToString());
                    product.Name = reader["Product_Name"].ToString();
                    product.Value = Convert.ToInt32(reader["price"]);
                    product.Description = reader["description"].ToString();
                    product.Store = new Store() { Cnpj = reader["cnpj"].ToString() };

                }

                return product;
            }
            catch
            {
                return null;
            }
            finally
            {
                fabric.CloseConnection();
            }
        }

    }
}
