using MySql.Data.MySqlClient;

namespace Software.Menu.Models
{
    public class Database
    {

        MySqlConnection connection = null;

        string conn = $@"Persist Security info = false;
                                server = localhost;
                                database = menusystem;
                                uid = brunohoske;
                                port = 3307;
                                pwd = 123;";

        public MySqlConnection GetConnection()
        {
            try
            {
                connection = new MySqlConnection(conn);
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            

            return connection;
        }

        public MySqlDataReader ExecuteCommandReader(string sql)
        {
            try
            {
               
                using MySqlCommand cmd = new MySqlCommand(sql, connection = GetConnection());
                var reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public void ExecuteCommand(string sql)
        {
            try
            {
                GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public void CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }


        }




    }
}
