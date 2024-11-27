using MySql.Data.MySqlClient;
using Restaurante.Models;
using Restaurante.Data;
using System.Globalization;
using System.Data;

namespace Restaurante.DAO
{
    internal class DAOProduto
    {
        MySqlConnection conexao = null;
        FabricaConexao f = new FabricaConexao();

        MySqlDataReader reader;

        public void Insert(Produto c)
        {
            MySqlConnection conexao = null;
            int ativo = c.IsActive ? 1 : 0;
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                comando.CommandText = "INSERT INTO products ( PRODUCT_NAME,PRICE,DESCRIPTION, CNPJ, ACTIVE)" +
                $"values('{c.Nome}',{c.Preco.ToString(CultureInfo.InvariantCulture)},'{c.Descricao}',42591651000143, {ativo})";
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
            int ativo = c.IsActive ? 1 : 0;
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                string tabela = "products";
                comando.CommandText = $@"UPDATE {tabela}
                SET idProduct = {c.Id},
                product_name = '{c.Nome}',
                price = {c.Preco},
                description= '{c.Descricao}',
                active = {ativo}
                
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

        public Produto FindProduct(int id)
        {
            Produto produto = null;
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                comando.CommandText = $"SELECT * FROM products WHERE idProduct = {id}";
                reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    produto = new Produto
                    {
                        Id = reader.GetInt32("IDPRODUCT"),
                        Nome = reader.GetString("PRODUCT_NAME"),
                        Preco = reader.GetFloat("PRICE"),
                        Descricao = reader.GetString("DESCRIPTION"),
                        IsActive = reader.GetInt32("ACTIVE") == 1
                    };
                }

                reader.Close();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Problemas ao buscar produto: " + ex.Message);
            }
            finally
            {
                f.Conectar().Close();
            }

            return produto;
        }

        public DataTable GetPedidosByProduto(int produtoId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                comando.CommandText = @"
                    SELECT o.idorder, o.order_date, o.total, o.order_status
                    FROM orders o
                    INNER JOIN order_details od ON o.idorder = od.idorder
                    WHERE od.idproduct = @produtoId";
                comando.Parameters.AddWithValue("@produtoId", produtoId);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(comando))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Problemas ao buscar pedidos: " + ex.Message);
            }
            finally
            {
                f.Conectar().Close();
            }

            return dataTable;
        }
    }
}

