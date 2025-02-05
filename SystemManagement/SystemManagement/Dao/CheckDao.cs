using MySql.Data.MySqlClient;
using SystemManagement.Data;
using SystemManagement.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SystemManagement.Dao
{
    public class CheckDao
    {
        MySqlConnection conexao = null;
        ConnectionFabric fabric = new ConnectionFabric();

        public int CloseCheck(Table table)
        {
            conexao = fabric.Connect();
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
                fabric.CloseConnection();
            }
          
        }

        public int GetCheckValue(Table table)
        {
            conexao = fabric.Connect();
            int value = 0;
            string sql = $"SELECT SUM(TOTAL) AS total FROM orders WHERE CHECK_NUMBER = {table.TableNumber} AND ORDER_ACTIVE and = 1 and CNPJ = '{table.Store.Cnpj}'";

            try {
                using var reader = fabric.ExecuteCommandReader(sql);
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
            finally
            {
                conexao.Close();
                fabric.CloseConnection();
            }
        }
    }
}
