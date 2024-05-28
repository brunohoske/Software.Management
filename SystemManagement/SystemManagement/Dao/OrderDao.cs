using MySql.Data.MySqlClient;
using SystemManagement.Data;
using SystemManagement.Models;

namespace SystemManagement.DAO
{
    public class OrderDao
    {
        MySqlConnection conexao = null;
        ConnectionFabric f = new ConnectionFabric();
        public void CreateOrder(Order order)
        {
            try
            {
                conexao = f.Connect();
                var command = conexao.CreateCommand();
                command.CommandText = $"Insert into Orders(cnpj,value,date,check_number) Values('{order.Store.Cnpj}',{order.Value},'{order.Date}',{order.Table} )";

                command.ExecuteNonQuery();
                
                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir Pedido");
            }
        }

    }
}
