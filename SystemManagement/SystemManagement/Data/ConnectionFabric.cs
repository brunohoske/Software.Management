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

        public MySqlDataReader ExecuteCommandReader(string sql)
        {
            try
            {
                using MySqlCommand cmd = new MySqlCommand(sql, conexao = Connect());
                var reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        public void CloseConnection()
        {
            if (conexao != null && conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }


        }
    }
}
