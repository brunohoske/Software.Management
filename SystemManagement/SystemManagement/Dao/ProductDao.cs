using MySql.Data.MySqlClient;
using SystemManagement.Data;
using SystemManagement.Models;

namespace SystemManagement.Dao
{
    public class ProductDao : BaseDao
    {
        MySqlConnection conexao = null;
        ConnectionFabric f = new ConnectionFabric();
        MySqlDataReader reader;
        public List<Product> GetProducts(Store s)
        {
            List<Product> products = new List<Product>();
            try
            {
                conexao = f.Connect();
                reader = f.ExecuteCommandReader($"SELECT * FROM PRODUCTS WHERE CNPJ = {s.Cnpj}", reader);
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
        }
        public Product GetProductFromId(int id)
        {
            reader = f.ExecuteCommandReader($"SELECT * FROM PRODUCTS WHERE ID PRODUCT = {id}", reader);
            Product p = new Product();
            while (reader.Read())
            {
                p.Id = Convert.ToInt32(reader.Read());
                p.Name = reader["Product_Name"].ToString();
                p.Value = Convert.ToInt32(reader["price"]);
                p.Description = reader["description"].ToString();
                p.Store = new Store() { Cnpj = reader["cnpj"].ToString() };
                
            }

            return p;
        }

    }
}
