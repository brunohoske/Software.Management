using MySql.Data.MySqlClient;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.DAO
{
    internal class DAOUsers
    {
        MySqlConnection conexao = null;
        FabricaConexao f = new FabricaConexao();

        MySqlDataReader reader;



        public Users SearchUser(string name)
        {
            try
            {

                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                comando.CommandText = $"SELECT * FROM USERS WHERE NAME = '{name}'";
                reader = comando.ExecuteReader();


                int ativo = 0;

                Users user = new Users();
                
                while (reader.Read())
                {
                    user.Id = int.Parse(reader["IDUSER"].ToString());
                    user.Nome = reader["NAME"].ToString();
                    user.Senha = reader["senha"].ToString();
                    user.Codigo = int.Parse(reader["ADMIN"].ToString());
                    ativo = int.Parse(reader["USER_ACTIVE"].ToString()) ;
                    user.Cnpj = reader["CNPJ"].ToString();
                }
                
                reader.Close();
                if (user.Nome != "")
                {
                    bool status_ativo = (ativo == 1? true : false);
                    user.IsActive = status_ativo;
                    return user;
                }
                else
                {
                    return null;
                }

            }
            catch (MySqlException ex)
            {
                throw new Exception("Problemas ao consultar no banco" + ex.Message);
            }
            finally
            {
                f.Conectar().Close();
            }
        }
        public bool ValidatePass(Users u, string password)
        {
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                comando.CommandText = $"select senha from USERS where IDUSER = {u.Id}";
                reader = comando.ExecuteReader();

                string pass = "";
                while (reader.Read())
                {
                    pass = reader["senha"].ToString();
                }

                reader.Close();
                if(password == pass)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (MySqlException ex)
            {
                throw new Exception("Problemas ao consultar no banco" + ex.Message);
            }
            finally
            {
                f.Conectar().Close();
            }
        }

        public void Select(Users u)
        {
            try
            {

                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                comando.CommandText = $"select * from usuarios where nome = {u.Nome}";
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["nome"].ToString(); 
                }

            }
            catch (MySqlException ex)
            {
                throw new Exception("Problemas ao consultar no banco" + ex.Message);
            }
            finally
            {
                f.Conectar().Close();
            }
        }

        public void Update(Users c)
        {
            int ativo = c.IsActive ? 1 : 0;
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                string tabela = "Users";
                comando.CommandText = String.Format($@"UPDATE {tabela}
                SET NAME = '{c.Nome}',
                SENHA = '{c.Senha}',
                CNPJ  = '42591651000143',
                Admin = '{c.Codigo}',
                USER_ACTIVE = {ativo}
                WHERE idUser= '{c.Id}';");
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Problemas ao atualizar o banco!" + ex.Message);
            }
            finally
            {
                f.Conectar().Close();
            }
        }


        public void Insert(Users c)
        {
            int ativo = c.IsActive ? 1 : 0;
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                comando.CommandText = "INSERT INTO Users (NAME,SENHA,CNPJ,ADMIN,USER_ACTIVE)" +
                "values('" + c.Nome + "','" + c.Senha + "','" + "42591651000143" + "','" + c.Codigo + "','"+ ativo + "')";
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

        public void Delete(Users c) 
        {
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                string tabela = "Users";
                comando.CommandText = String.Format($@"DELETE from {tabela} 
                WHERE IDUSER = '{c.Id}';");
                comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                throw new Exception("Problemas ao apagar no banco!" + ex.Message);
            }
            finally
            {
                f.Conectar().Close();
            }
        }


    }
}
