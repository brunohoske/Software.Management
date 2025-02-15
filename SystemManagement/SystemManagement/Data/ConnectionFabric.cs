using MySql.Data.MySqlClient;

namespace SystemManagement.Data
{
    public class ConnectionFabric
    {
        public MySqlConnection Connect()
        {
            MySqlConnection conexao;
            try
            {
              
                string conn = @"Persist Security info = false;
                                server = localhost;
                                database = menusystem;
                                uid = hoske;
                                port= 3306;
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

        public MySqlDataReader ExecuteCommandReader(string sql, MySqlConnection conexaoExterna)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conexaoExterna);
                var reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        
    }
}
