using MySql.Data.MySqlClient;

namespace Restaurante.Data
{
    internal class FabricaConexao
    {
        MySqlConnection conexao = null;

        public MySqlConnection Conectar()
        {
            try
            {
                string conn = @"Persist Security info = false;
                                server = localhost;
                                database = MenuSystem;
                                port = 3307;
                                uid = brunohoske;
                                pwd = 123;";

                conexao = new MySqlConnection(conn);
                conexao.Open();
                Console.WriteLine("Conectado");
            }
            catch (MySqlException)
            {
                throw new Exception("Houve um erro ao se conectar com o banco de dados");
            }

            return conexao;
        }
    }
}
