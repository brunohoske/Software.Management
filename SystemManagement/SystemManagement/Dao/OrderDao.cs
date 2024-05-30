using MySql.Data.MySqlClient;
using SystemManagement.Data;
using SystemManagement.Models;

namespace SystemManagement.DAO
{
    public class OrderDao
    {
        MySqlConnection conexao = null;
        ConnectionFabric f = new ConnectionFabric();
        MySqlDataReader reader;

        

        public List<Product> GetProduct(Store s)
        {
            List<Product> products = new List<Product>();
            try
            {
                conexao = f.Connect();
                reader = f.ExecuteCommandReader($"SELECT * FROM PRODUCTS WHERE CNPJ = {s.Cnpj}", reader);
                while (reader.Read())
                {
                    Product p = new Product();

                    p.Name = reader["Product_name"].ToString();
                    p.Value = Convert.ToInt32(reader["PRICE"]);
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

        public void CreateOrder(Order order)
        {
            try
            {
                string dt = order.Date.ToString("yyyy-MM-dd HH:mm:ss");
                conexao = f.Connect();
                var command = conexao.CreateCommand();
                command.CommandText = $"Insert into Orders(cnpj,total,order_date,check_number) Values('{order.Store.Cnpj}',{order.Value},'{dt}',{order.Table.TableNumber} )";

                command.ExecuteNonQuery();
                
                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir Pedido");
            }
        }

    }
}
