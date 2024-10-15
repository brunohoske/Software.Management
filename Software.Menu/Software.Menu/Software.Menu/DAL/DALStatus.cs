using MySql.Data.MySqlClient;
using Software.Menu.Models;


namespace Software.Menu.DAL
{
    public class DALStatus
    {

        MySqlConnection conexao = null;
        Database database = new Database();

        public string GetStatus(int Status)
        {
            try
            {
               
                using var reader = database.ExecuteCommandReader("SELECT ORDER_STATUS FROM ORDERS");
                
                int ValorStatus = 0;

                while (reader.Read())
                {
                   ValorStatus = int.Parse(reader["ORDER_STATUS"].ToString());
                }

                return CheckStatus(ValorStatus);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                database.CloseConnection();
            }
        }


        public string CheckStatus(int status) 
        {
            string statuspedido = "";

            if (status == 1)
            {
                statuspedido = "Pendente";
            } else if (status == 2)
            {
                statuspedido = "Em andamento";
            } else if (status == 3)
            {
                statuspedido = "Finalizado";
            }

            return (statuspedido);
        }

    }
}
