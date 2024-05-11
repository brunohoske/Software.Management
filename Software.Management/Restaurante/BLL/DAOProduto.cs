using MySql.Data.MySqlClient;
using Restaurante.DTO;
using Restaurante.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Restaurante.BLL
{
    internal class DAOProduto
    {
        MySqlConnection conexao = null;
        FabricaConexao f = new FabricaConexao();


        public void Insert(Produto c)
        {
                MySqlConnection conexao = null;
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                comando.CommandText = "INSERT INTO produtos ( nome, preco, quantidade)" +
                "values('" + c.Nome + "','" + c.Preco.ToString(CultureInfo.InvariantCulture) + "','" + c.Qntd + "')";
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Problemas ao INSERIR no banco" + ex.Message);
            }
            finally
            {
                f.Conectar().Close();
            }
        }

        public void Update(Produto c)
        {
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                string tabela = "produtos";
                comando.CommandText = $@"UPDATE {tabela}
                SET idProdutos = {c.Id},
                nome = '{c.Nome}',
                preco = {c.Preco},
                quantidade = {c.Qntd}
                Where idProdutos = {c.Id};";
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Problemas ao Alterar no banco" + ex.Message);
            }
            finally
            {
                f.Conectar().Close();
            }
        }

        public void Delete(Produto c)
        {
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                string tabela = "produtos";
                comando.CommandText = String.Format($@"DELETE from {tabela} 
                WHERE idProdutos = '{c.Id}';");
                comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                throw new Exception("problemas ao APAGAR no banco" + ex.Message);
            }
            finally
            {
                f.Conectar().Close();
            }
        }

    }
}
