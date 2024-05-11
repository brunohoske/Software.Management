using MySql.Data.MySqlClient;
using Restaurante.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante.DTO;

namespace Restaurante.BLL
{
    internal class DALUsers
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
                comando.CommandText = $"select * from usuarios where nome = '{name}'";
                reader = comando.ExecuteReader();

                string readName = "";
                int id = 0;
                string password = "";
                int codigo = 0;
                while (reader.Read())
                {
                    id = int.Parse(reader["idUsuarios"].ToString());
                    readName = reader["nome"].ToString();
                    password = reader["senha"].ToString();
                    codigo = int.Parse(reader["codigo"].ToString());
                }

                reader.Close();
                if (readName != "")
                {
                    return new Users() { Id = id, Codigo = codigo, Nome = name, Senha = password};
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
                comando.CommandText = $"select senha from usuarios where idUsuarios = {u.Id}";
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

    }
}
