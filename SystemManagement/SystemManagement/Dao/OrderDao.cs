using MySql.Data.MySqlClient;
using SystemManagement.Dao;
using SystemManagement.Data;
using SystemManagement.Models;

namespace SystemManagement.DAO
{
    public class OrderDao 

    {

        MySqlConnection conexao = null;
        ConnectionFabric f = new ConnectionFabric();
        MySqlDataReader reader;
        MySqlDataReader reader2;
        MySqlDataReader reader3;
        public int GetOrderNumber(Store s)
        {
            int number = 0;
            try
            {
                conexao = f.Connect();
                reader3 = f.ExecuteCommandReader($"SELECT IDORDER FROM ORDERS WHERE CNPJ = {s.Cnpj} ORDER BY IDORDER DESC LIMIT 1", reader3);
                while (reader3.Read())
                {
                    number = Convert.ToInt32(reader3["IdOrder"]);
                }

                return number + 10;
            }
            
            catch (Exception e)
            {
                return 0;
            }

        }

        public void CreateOrder(Order order)
        {
            try
            {
                order.Id = GetOrderNumber(order.Store);
                string dt = order.Date.ToString("yyyy-MM-dd HH:mm:ss");
                conexao = f.Connect();
                var command = conexao.CreateCommand();
                command.CommandText = $"Insert into Orders(idorder,cnpj,total,order_date,check_number,order_active) Values({order.Id},'{order.Store.Cnpj}',{order.Value},'{dt}',{order.Table.TableNumber},1 )";

                command.ExecuteNonQuery();
                for (int i = 0;i < order.Products.Count;i++)
                {
                    command.CommandText = $"INSERT INTO order_details(idorder,cnpj,idproduct,item,check_number,price,order_date) VALUES({order.Id},'{order.Store.Cnpj}',{order.Products[i].Id} ,{i+1},{order.Table.TableNumber},{order.Products[i].Value},'{dt}')";
                    command.ExecuteNonQuery();

                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir Pedido");
            }
        }

        public List<Order> GetOrders(Store s)
        {
            List<Order> orders = new List<Order>();

            try
            {
                conexao = f.Connect();
                reader = f.ExecuteCommandReader($"SELECT * FROM ORDERS WHERE CNPJ = '{s.Cnpj}' AND ORDER_ACTIVE = 1",reader);

                while (reader.Read())
                {
                    Order o = new Order();

                    o.Id = Convert.ToInt32(reader["idorder"]);
                    o.Products = GetOrderProduct(o);
                    o.Value = Convert.ToDouble(reader["total"]);
                    o.Table = new Table() { Store = s, TableNumber = Convert.ToInt32(reader["check_number"]) };
                    o.Date = Convert.ToDateTime(reader["order_date"]);
                    orders.Add(o);
                }

                return orders;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Product> GetOrderProduct(Order order)
        {
            List<Product> products = new List<Product>();
            List<int> orderProducts = new List<int>();
            try
            {
              
                conexao = f.Connect();
                reader2 = f.ExecuteCommandReader($"SELECT idproduct FROM order_details where idorder = {order.Id}", reader2);
                while (reader2.Read())
                {
                    orderProducts.Add(Convert.ToInt32(reader2["idproduct"]));
                }

               foreach (int i in orderProducts)
                {
                    ProductDao productDao = new ProductDao();
                    products.Add(productDao.GetProductFromId(i));
                }
                
                return products;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<Order> GetOrdersInTable(Store s, Table t)
        {
            List<Order> orders = new List<Order>();

            try
            {
                conexao = f.Connect();
                reader = f.ExecuteCommandReader($"SELECT * FROM ORDERS WHERE CNPJ = '{s.Cnpj}' AND ORDER_ACTIVE = 1 AND CHECK_NUMBER = {t.TableNumber}", reader);

                while (reader.Read())
                {
                    Order o = new Order();

                    o.Id = Convert.ToInt32(reader["idorder"]);
                    o.Products = GetOrderProduct(o);
                    o.Value = Convert.ToDouble(reader["total"]);
                    o.Table = new Table() { Store = s, TableNumber = Convert.ToInt32(reader["check_number"]) };
                    o.Date = Convert.ToDateTime(reader["order_date"]);
                    orders.Add(o);
                }

                return orders;
            }
            catch (Exception e)
            {
                return null;
            }
        }




    }
}
