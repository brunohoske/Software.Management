using MySql.Data.MySqlClient;
using Restaurante.Data;
using Restaurante.Models;


namespace Restaurante.DAO
{
    public class DAOStore
    {
        MySqlConnection conexao = null;
        FabricaConexao f = new FabricaConexao();

        MySqlDataReader reader;

        public Store GetCompanyFromCNPJ(string cnpj)
        {
            Store store = new Store();
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                comando.CommandText = $"SELECT * FROM companys WHERE CNPJ = {cnpj}";
                reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    store = new Store
                    {
                        Cnpj = reader.GetString(0),
                        Name = reader.GetString(1),
                        Logo = reader.GetString(2)
                    };
                }
                
                reader.Close();
                return store;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Problemas ao buscar a loja: " + ex.Message);
            }
            finally
            {
                f.Conectar().Close();
            }
        }




    }
}
