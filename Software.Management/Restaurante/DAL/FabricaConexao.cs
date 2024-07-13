using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Restaurante.DAL
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
                                uid = brunohoske;
                                port = 3307;
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
