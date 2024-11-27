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

        public int GetOrderNumber(Store s)
        {
            int number = 0;
            try
            {
                using var reader = f.ExecuteCommandReader($"SELECT IDORDER FROM ORDERS WHERE CNPJ = {s.Cnpj} ORDER BY IDORDER DESC LIMIT 1");
                while (reader.Read())
                {
                    number = Convert.ToInt32(reader["IdOrder"]);
                }

                return number + 10;
            }
            
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                f.CloseConnection();
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
                command.CommandText = $"Insert into Orders(idorder,cnpj,total,order_date,check_number,order_active,order_status) Values({order.Id},'{order.Store.Cnpj}',{order.Value},'{dt}',{order.Table.TableNumber},1,1)";

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
            finally
            {
                conexao.Close();
                f.CloseConnection();
            }
        }

        public List<Order> GetOrders(Store s)
        {
            List<Order> orders = new List<Order>();

            try
            {
                using var reader = f.ExecuteCommandReader($"SELECT * FROM ORDERS WHERE CNPJ = '{s.Cnpj}' AND ORDER_ACTIVE = 1");

                while (reader.Read())
                {
                    Order o = new Order();

                    o.Id = Convert.ToInt32(reader["idorder"]);
                    o.Products = GetOrderProduct(o);
                    o.Value = Convert.ToDouble(reader["total"]);
                    o.Table = new Table() { Store = s, TableNumber = Convert.ToInt32(reader["check_number"]) };
                    o.Date = Convert.ToDateTime(reader["order_date"]);
                    o.Status = Convert.ToInt32(reader["order_status"]);
                    o.Store = s;
                    orders.Add(o);
                }

                return orders;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                f.CloseConnection();
            }
        }

        public List<Product> GetOrderProduct(Order order)
        {
            List<Product> products = new List<Product>();
            List<int> orderProducts = new List<int>();
            try
            {
              
                using var reader = f.ExecuteCommandReader($"SELECT idproduct FROM order_details where idorder = {order.Id}");
                while (reader.Read())
                {
                    orderProducts.Add(Convert.ToInt32(reader["idproduct"]));
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
            finally
            {
                f.CloseConnection();
            }
        }


        public List<Order> GetOrdersInTable(Store s, Table t)
        {
            List<Order> orders = new List<Order>();

            try
            {
                using var reader = f.ExecuteCommandReader($"SELECT * FROM ORDERS WHERE CNPJ = '{s.Cnpj}' AND ORDER_ACTIVE = 1 AND CHECK_NUMBER = {t.TableNumber}");
            

                while (reader.Read())
                {
                    Order o = new Order();

                    o.Id = Convert.ToInt32(reader["idorder"]);
                    o.Products = GetOrderProduct(o);
                    o.Value = Convert.ToDouble(reader["total"]);
                    o.Table = new Table() { Store = s, TableNumber = Convert.ToInt32(reader["check_number"]) };
                    o.Status = Convert.ToInt32(reader["order_status"]);
                    o.Date = Convert.ToDateTime(reader["order_date"]);
                    orders.Add(o);
                }

                return orders;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                f.CloseConnection();
            }
        }

        public int CompleteOrder(Order order) 
        {

            try
            {
                string com = $"Update orders set order_status = 3 where idorder = {order.Id}";
                conexao = f.Connect();
                MySqlCommand cmd = new MySqlCommand(com, conexao);


                return cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;

                return 0;
            }
            finally
            {
                conexao.Close();
                f.CloseConnection();
            }
            

        }

        



    }
}
