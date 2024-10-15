using MySql.Data.MySqlClient;
using SystemManagement.Data;
using SystemManagement.Models;

namespace SystemManagement.Dao
{
    public class CheckDao
    {
        MySqlConnection conexao = null;
        ConnectionFabric f = new ConnectionFabric();

        public int CloseCheck(Table table)
        {
            conexao = f.Connect();
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
                f.CloseConnection();
            }
          
        }
    }
}
