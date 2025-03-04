using MySql.Data.MySqlClient;
using System.Globalization;
using SystemManagement.Dao;
using SystemManagement.Data;
using SystemManagement.DTOs;
using SystemManagement.Models;

namespace SystemManagement.DAO
{
    public class OrderDao 
    {
        private readonly ConnectionFabric _connectionFabric;
        private readonly ProductDao _productDao;

        public OrderDao(ConnectionFabric connectionFabric,ProductDao productDao)
        {
            _connectionFabric = connectionFabric;
            _productDao = productDao;
        }
        public int _GetOrderNumber(Store store)
        {
            int number = 0;
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var cmd = conexao.CreateCommand();
                cmd.CommandText = $"SELECT IDORDER FROM ORDERS WHERE idComapny = {store.Id} ORDER BY IDORDER DESC LIMIT 1";
                var result = cmd.ExecuteScalar();
                number = Convert.ToInt32(result);
                return number + 10;
            }
            
            catch (Exception ex)
            {
                return 0;
            }

        }


        public int GetOrderNumber(Store store)
        {
            int number = 0;
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var cmd = conexao.CreateCommand();
                cmd.CommandText = $"SELECT if(IDORDER = 0, 1, idorder) FROM ORDERS WHERE idcompany = {store.Id} ORDER BY IDORDER DESC LIMIT 1";
                var result = cmd.ExecuteScalar();
                number = Convert.ToInt32(result);
                return number;
            }

            catch (Exception ex)
            {
                return 0;
            }

        }

        public void CreateOrder(OrderDTO order)
        {
            using var conexao = _connectionFabric.Connect();
            using var transaction = conexao.BeginTransaction();
            try
            {
                string dt = order.Date.ToString("yyyy-MM-dd HH:mm:ss");
                
                
                using var command = conexao.CreateCommand();
                command.CommandText = $"Insert into Orders(idcompany,total,order_date,check_number,order_active,order_status) Values(@idcompany,@value,@data,@table_number,1,1)";

                command.Parameters.AddWithValue("@idcompany", order.Store.Id);
                command.Parameters.AddWithValue("@value", order.Value);
                command.Parameters.AddWithValue("@data", dt);
                command.Parameters.AddWithValue("@table_number", order.Table.TableNumber);
                command.ExecuteNonQuery();
                order.Id = (int)command.LastInsertedId;
                command.Parameters.AddWithValue("@idorder", order.Id);
                for (int i = 0;i < order.Products.Count;i++)
                {
                    command.CommandText = $"INSERT INTO order_details (idorder,idcompany,idproduct,item,check_number,price,order_date,note) VALUES(@idorder,@idcompany,@idproduct{i} ,@item{i},@table_number,@price{i},@data,@note{i})";
                    
                    command.Parameters.AddWithValue("@idproduct"+i, order.Products[i].Id);
                    command.Parameters.AddWithValue("@item"+i, i + 1);
                    command.Parameters.AddWithValue("@price"+i, order.Products[i].Value);
                    command.Parameters.AddWithValue("@note"+i, order.Products[i].Note);
                    command.ExecuteNonQuery();

                }
                transaction.Commit();

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }

        public List<Order> GetOrders(Store store)
        {
            List<Order> orders = new List<Order>();

            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM ORDERS WHERE idCompany = {store.Id} AND ORDER_ACTIVE = 1", conexao);

                while (reader.Read())
                {
                    Order order = new Order();

                    order.Id = Convert.ToInt32(reader["idorder"]);
                    order.Products = GetOrderProduct(order,store);
                    
                    order.Value = Convert.ToDecimal(reader["total"]);    
                    order.Table = new Table() { Store = store, TableNumber = Convert.ToInt32(reader["check_number"]) };
                    order.Date = Convert.ToDateTime(reader["order_date"]);
                    order.Status = Convert.ToInt32(reader["order_status"]);
                    order.Store = store;
                    orders.Add(order);
                }

                return orders;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Product> GetOrderProduct(Order order, Store store)
        {
            try
            {
                var products = _productDao.GetProductsFromOrder(order.Id, store);
                return products;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GetProductNote(int idProduct, int idOrder, Store store)
        {
            using var conexao = _connectionFabric.Connect();
            using var cmd = conexao.CreateCommand();
            cmd.CommandText = $"SELECT note FROM order_details WHERE idproduct = {idProduct} AND idorder = {idOrder} AND idcompany = {store.Id}";
            var result = cmd.ExecuteScalar();
            string note = Convert.ToString(result);
            return note;
        }
        public List<Order> GetOrdersInTable(Store store, Table t)
        {
            List<Order> orders = new List<Order>();

            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM ORDERS o" +
                    $" WHERE idcompany = {store.Id} AND ORDER_ACTIVE = 1 AND CHECK_NUMBER = {t.TableNumber}", conexao);



                while (reader.Read())
                {
                    Order order = new Order();

                    order.Id = Convert.ToInt32(reader["idorder"]);
                    order.Products = GetOrderProduct(order,store);
                    order.Value = Convert.ToDecimal(reader["total"]);
                    order.Table = new Table() { Store = store, TableNumber = Convert.ToInt32(reader["check_number"]) };
                    order.Status = Convert.ToInt32(reader["order_status"]);
                    order.Date = Convert.ToDateTime(reader["order_date"]);
                    orders.Add(order);
                }

                return orders;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int CompleteOrder(Order order, Store store) 
        {

            try
            {
                string com = $"update orders set order_status = 3 where idorder = {order.Id} and icCompany = {store.Id}";
                using var conexao = _connectionFabric.Connect();
                MySqlCommand cmd = new MySqlCommand(com, conexao);
                return cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }

        }
    }
}
