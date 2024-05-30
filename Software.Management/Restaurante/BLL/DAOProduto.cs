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
                comando.CommandText = "INSERT INTO products ( PRODUCT_NAME,PRICE,DESCRIPTION, CNPJ)" +
                $"values('{c.Nome}',{c.Preco.ToString(CultureInfo.InvariantCulture)},'{c.Descricao}',42591651000143)";
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
                string tabela = "products";
                comando.CommandText = $@"UPDATE {tabela}
                SET idProduct = {c.Id},
                product_name = '{c.Nome}',
                price = {c.Preco},
                description= '{c.Descricao}'
                Where idProduct = {c.Id};";
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
                string tabela = "products";
                comando.CommandText = String.Format($@"DELETE from {tabela} 
                WHERE idProduct = '{c.Id}';");
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
