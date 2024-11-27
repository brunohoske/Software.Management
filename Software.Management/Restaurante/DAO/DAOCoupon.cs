using MySql.Data.MySqlClient;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.DAO
{
    public class DAOCoupon
    {
        MySqlConnection conexao = null;
        FabricaConexao f = new FabricaConexao();
        public void Cadastrar(Coupon coupon)
        {
            int ativo = coupon.Active ? 1 : 0;
            try
            {

                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                comando.CommandText = "INSERT INTO COUPON (CODE, DISCOUNT, ACTIVE)" +
                $"values('{coupon.Code}', {coupon.Discount}, {ativo})";
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

        public void Update(Coupon coupon)
        {
            int ativo = coupon.Active ? 1 : 0;
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                string tabela = "COUPON";
                comando.CommandText = $@"UPDATE {tabela}
                SET DISCOUNT = '{coupon.Discount}',
                CODE = '{coupon.Code}',
                ACTIVE = {ativo} 
                WHERE COUPONID = {coupon.CouponId}";
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Problemas ao alterar o cupom" + ex.Message);
            }
            finally
            {
                f.Conectar().Close();
            }
        }


        public void Delete(Coupon coupon)
        {
            try
            {
                conexao = f.Conectar();
                var comando = conexao.CreateCommand();
                string tabela = "COUPON";
                comando.CommandText = String.Format($@"DELETE from {tabela} 
                WHERE COUPONID = '{coupon.CouponId}';");
                comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                throw new Exception("problemas ao apagar o cupom" + ex.Message);
            }
            finally
            {
                f.Conectar().Close();
            }
        }
    }
}
