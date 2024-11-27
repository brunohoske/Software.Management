using MySql.Data.MySqlClient;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.DAO
{
    internal class DAODiscount
    {
        MySqlConnection conexao = null;
        FabricaConexao f = new FabricaConexao();


        public void Cadastrar(Discount d)
        {
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                comando.CommandText = "INSERT INTO DISCOUNT (DISCOUNT_PERCENTAGE, CNPJ, IDPRODUCT)" +
                $"values({d.DiscountPercent}, {d.Cnpj}, {d.Id_Produto})";
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Problemas ao Cadastrar " + ex.Message);
            }
            finally
            {
                f.Conectar().Close();
            }
        }

        public void Update(Discount d, double newNumber)
        {
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                string tabela = "DISCOUNT";
                comando.CommandText = $@"UPDATE {tabela}
                SET DISCOUNT_PERCENTAGE = '{newNumber}' 
                WHERE ID_DISCOUNT = {d.Id}";
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Problemas ao alterar mesa" + ex.Message);
            }
            finally
            {
                f.Conectar().Close();
            }
        }


        public void Delete(Discount d)
        {
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                string tabela = "DISCOUNT";
                comando.CommandText = String.Format($@"DELETE from {tabela} 
                WHERE ID_DISCOUNT = '{d.Id}';");
                comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                throw new Exception("problemas ao apagar mesa" + ex.Message);
            }
            finally
            {
                f.Conectar().Close();
            }
        }
    }
}
