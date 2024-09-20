using MySql.Data.MySqlClient;
using Restaurante.DAL;
using Restaurante.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.BLL
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
