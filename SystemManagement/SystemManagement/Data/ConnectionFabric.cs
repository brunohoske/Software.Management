using MySql.Data.MySqlClient;

namespace SystemManagement.Data
{
    public class ConnectionFabric
    {

        MySqlConnection conexao = null;

        public MySqlConnection Connect()
        {
            try
            {
                string conn = @"Persist Security info = false;
                                server = localhost;
                                database = menusystem;
                                uid = brunohoske;
                                port= 3307;
                                pwd =123";

                conexao = new MySqlConnection(conn);
                conexao.Open();
            }
            catch (MySqlException)
            {
                throw new Exception("Houve um erro ao se conectar com o banco de dados");
            }

            return conexao;
        }

        public MySqlDataReader ExecuteCommandReader(string sql, MySqlDataReader read)
        {
            try
            {

                Connect();
                MySqlCommand cmd = new MySqlCommand(sql, Connect());
                read = cmd.ExecuteReader();
                return read;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
