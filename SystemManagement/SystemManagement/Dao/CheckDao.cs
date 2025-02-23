﻿using MySql.Data.MySqlClient;
using SystemManagement.Data;
using SystemManagement.Models;

namespace SystemManagement.Dao
{
    public class CheckDao
    {
        private readonly ConnectionFabric _connectionFabric;
        public CheckDao(ConnectionFabric connectionFabric)
        {
            _connectionFabric = connectionFabric;
        }

        public int CloseCheck(Table table)
        {
            using var conexao = _connectionFabric.Connect();
            string sql = $"UPDATE Orders SET ORDER_ACTIVE = 0 WHERE check_number = {table.TableNumber}";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                conexao.Close();
                
            }
          
        }

        public int GetCheckValue(Table table)
        {
            
            int value = 0;
            string sql = $"SELECT SUM(TOTAL) AS total FROM orders WHERE CHECK_NUMBER = {table.TableNumber} AND ORDER_ACTIVE and = 1 and CNPJ = '{table.Store.Cnpj}'";

            try 
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader(sql, conexao);
                while (reader.Read())
                {
                     value = Convert.ToInt32(reader["total"]);
                }

                return value;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
