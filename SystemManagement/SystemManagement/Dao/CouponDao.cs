using MySql.Data.MySqlClient;
using SystemManagement.Data;
using SystemManagement.Models;

namespace SystemManagement.Dao
{
    public class CouponDao
    {
        MySqlConnection conexao = null;
        ConnectionFabric f = new ConnectionFabric();

        public Coupon SearchCouponFromCode(string code)
        {
            Coupon coupon = new Coupon();
            try
            {
                using var reader = f.ExecuteCommandReader($"SELECT * FROM COUPON WHERE CODE = '{code}';");
                while (reader.Read())
                {
                    
                    coupon.CouponId = int.Parse(reader["COUPONID"].ToString());
                    coupon.Active = (int.Parse(reader["ACTIVE"].ToString()) == 1 ? true : false);
                    coupon.Code = reader["CODE"].ToString();
                    coupon.Discount = double.Parse(reader["DISCOUNT"].ToString());
                    return coupon;
                }
                

                return null;

            }

            catch (Exception e)
            {
                return null;

            }
            finally
            {
                f.CloseConnection();
            }
        }
    }
}
