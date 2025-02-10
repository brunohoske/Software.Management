﻿using MySql.Data.MySqlClient;
using SystemManagement.Dao;
using SystemManagement.Data;
using SystemManagement.DTOs;
using SystemManagement.Models;

namespace SystemManagement.DAO
{
    public static class OrderDao 

    {

        static MySqlConnection conexao = null;
        static ConnectionFabric fabric = new ConnectionFabric();

        public static int GetOrderNumber(Store store)
        {
            int number = 0;
            try
            {
                using var reader = fabric.ExecuteCommandReader($"SELECT IDORDER FROM ORDERS WHERE CNPJ = {store.Cnpj} ORDER BY IDORDER DESC LIMIT 1");
                while (reader.Read())
                {
                    number = Convert.ToInt32(reader["IdOrder"]);
                }

                return number + 10;
            }
            
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                fabric.CloseConnection();
            }

        }


        public static int GetOrderNumber2(Store store)
        {
            int number = 0;
            try
            {
                using var reader = fabric.ExecuteCommandReader($"SELECT IDORDER FROM ORDERS WHERE CNPJ = {store.Cnpj} ORDER BY IDORDER DESC LIMIT 1");
                while (reader.Read())
                {
                    number = Convert.ToInt32(reader["IdOrder"]);
                }

                return number;
            }

            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                fabric.CloseConnection();
            }

        }

        public static void CreateOrder(OrderDTO order)
        {
            try
            {
                string dt = order.Date.ToString("yyyy-MM-dd HH:mm:ss");
                conexao = fabric.Connect();
                var command = conexao.CreateCommand();
                command.CommandText = $"Insert into Orders(cnpj,total,order_date,check_number,order_active,order_status) Values('{order.Store.Cnpj}',{order.Value},'{dt}',{order.Table.TableNumber},1,1)";

                command.ExecuteNonQuery();
                order.Id = GetOrderNumber2(order.Store);
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
            finally
            {
                conexao.Close();
                fabric.CloseConnection();
            }
        }

        public static List<Order> GetOrders(Store store)
        {
            List<Order> orders = new List<Order>();

            try
            {
                using var reader = fabric.ExecuteCommandReader($"SELECT * FROM ORDERS WHERE CNPJ = '{store.Cnpj}' AND ORDER_ACTIVE = 1");

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
            finally
            {
                fabric.CloseConnection();
            }
        }

        public static List<Product> GetOrderProduct(Order order, Store store)
        {
            List<Product> products = new List<Product>();
            List<int> orderProducts = new List<int>();
            try
            {
              
                using var reader = fabric.ExecuteCommandReader($"SELECT idproduct FROM order_details where idorder = {order.Id}");
                while (reader.Read())
                {
                    orderProducts.Add(Convert.ToInt32(reader["idproduct"]));
                }

               foreach (int i in orderProducts)
               {
                    products.Add(ProductDao.GetProductFromId(i,store.Cnpj));
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


        public static List<Order> GetOrdersInTable(Store store, Table t)
        {
            List<Order> orders = new List<Order>();

            try
            {
                using var reader = fabric.ExecuteCommandReader($"SELECT * FROM ORDERS WHERE CNPJ = '{store.Cnpj}' AND ORDER_ACTIVE = 1 AND CHECK_NUMBER = {t.TableNumber}");
            

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
            finally
            {
                fabric.CloseConnection();
            }
        }

        public static int CompleteOrder(Order order) 
        {

            try
            {
                string com = $"Update orders set order_status = 3 where idorder = {order.Id}";
                conexao = fabric.Connect();
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
                fabric.CloseConnection();
            }
            

        }

        



    }
}
