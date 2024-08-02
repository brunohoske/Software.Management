﻿

using MySql.Data.MySqlClient;
using Restaurante.DAL;
using Restaurante.DTO;
using System.Data;

namespace Restaurante.BLL
{
    public class DAOOrder
    {
        MySqlConnection conexao = null;
        FabricaConexao f = new FabricaConexao();
        MySqlDataReader reader;

        public List<Order> GetAll()
        {
            conexao = f.Conectar();
            var cmd = conexao.CreateCommand();
            cmd.CommandText = "SELECT * FROM ORDERS";
            reader = cmd.ExecuteReader();

            List<Order> list = new List<Order>();

            while (reader.Read())
            {
                Order order = new Order()
                {
                    Id = Convert.ToInt32(reader["IDORDER"]),
                    Store = new Store() { Cnpj = "", Name = "McDonalds" },
                    Date = Convert.ToDateTime(reader["ORDER_DATE"])
                };
                list.Add(order);
            }

            return list;



        }

        public DataTable GetAll(DataTable table)
        {
            MySqlConnection conexao = null;
            FabricaConexao f = new FabricaConexao();
            conexao = f.Conectar();
            string sql = "SELECT * FROM ORDERS ORDER BY IDORDER";
            MySqlDataAdapter adap = new MySqlDataAdapter(sql, conexao);
            adap.Fill(table);
            return table;
        }
    }
}
