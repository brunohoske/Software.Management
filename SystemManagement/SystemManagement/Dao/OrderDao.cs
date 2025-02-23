﻿using MySql.Data.MySqlClient;
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
                cmd.CommandText = $"SELECT IDORDER FROM ORDERS WHERE CNPJ = {store.Cnpj} ORDER BY IDORDER DESC LIMIT 1";
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
                cmd.CommandText = $"SELECT IDORDER FROM ORDERS WHERE CNPJ = {store.Cnpj} ORDER BY IDORDER DESC LIMIT 1";
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
            try
            {
                string dt = order.Date.ToString("yyyy-MM-dd HH:mm:ss");
                using var conexao = _connectionFabric.Connect();
                using var command = conexao.CreateCommand();
                command.CommandText = $"Insert into Orders(cnpj,total,order_date,check_number,order_active,order_status) Values('{order.Store.Cnpj}',{order.Value},'{dt}',{order.Table.TableNumber},1,1)";
                command.ExecuteNonQuery();
                order.Id = GetOrderNumber(order.Store);
                for (int i = 0;i < order.Products.Count;i++)
                {
                    command.CommandText = $"INSERT INTO order_details(idorder,cnpj,idproduct,item,check_number,price,order_date,note) VALUES({order.Id},'{order.Store.Cnpj}',{order.Products[i].Id} ,{i + 1},{order.Table.TableNumber},{order.Products[i].Value},'{dt}','{order.Products[i].Note}')";
                    command.ExecuteNonQuery();

                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir Pedido");
            }
        }

        public List<Order> GetOrders(Store store)
        {
            List<Order> orders = new List<Order>();

            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM ORDERS WHERE CNPJ = '{store.Cnpj}' AND ORDER_ACTIVE = 1", conexao);

                while (reader.Read())
                {
                    Order order = new Order();

                    order.Id = Convert.ToInt32(reader["idorder"]);
                    order.Products = GetOrderProduct(order,store);
                    order.Value = Convert.ToDouble(reader["total"]);
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

        public List<Product> GetOrderProduct(Order order, Store store)
        {
            List<Product> products = new List<Product>();
            List<int> orderProducts = new List<int>();
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT idproduct FROM order_details where idorder = {order.Id}", conexao);
                while (reader.Read())
                {
                    orderProducts.Add(Convert.ToInt32(reader["idproduct"]));
                }

               foreach (int id in orderProducts)
               {
                    products.Add(_productDao.GetProductFromId(id, store.Cnpj));
               }
                
                return products;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<Order> GetOrdersInTable(Store store, Table t)
        {
            List<Order> orders = new List<Order>();

            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM ORDERS WHERE CNPJ = '{store.Cnpj}' AND ORDER_ACTIVE = 1 AND CHECK_NUMBER = {t.TableNumber}", conexao);
            

                while (reader.Read())
                {
                    Order order = new Order();

                    order.Id = Convert.ToInt32(reader["idorder"]);
                    order.Products = GetOrderProduct(order,store);
                    order.Value = Convert.ToDouble(reader["total"]);
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

        public int CompleteOrder(Order order) 
        {

            try
            {
                string com = $"update orders set order_status = 3 where idorder = {order.Id}";
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
