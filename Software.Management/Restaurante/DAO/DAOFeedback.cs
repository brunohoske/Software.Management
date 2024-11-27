using MySql.Data.MySqlClient;
using Restaurante.Data;
using System.Data;


namespace Restaurante.DAO
{
    public class DAOFeedback
    {
        MySqlConnection conexao = null;
        FabricaConexao f = new FabricaConexao();

        public DataTable ReadFeedbacks()
        {
            try
            {
                conexao = f.Conectar();
                string sql = "SELECT * from FEEDBACKS order by FEEDBACK_ID";
                MySqlDataAdapter adap = new MySqlDataAdapter(sql, conexao);
                DataTable tbFeedback = new DataTable();
                adap.Fill(tbFeedback);
                return tbFeedback;
            }
            catch
            {
                MessageBox.Show("Erro ao ler feedbacks");
                return null;
            }
            finally
            {
                conexao.Close();
            }
           
        }

    }
}
