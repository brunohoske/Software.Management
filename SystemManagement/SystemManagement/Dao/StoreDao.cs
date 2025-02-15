using MySql.Data.MySqlClient;
using SystemManagement.Data;
using SystemManagement.Models;

namespace SystemManagement.Dao
{
    public class StoreDao
    {
        MySqlConnection conexao = null;
        ConnectionFabric fabric = new ConnectionFabric();
        public Store GetCompanyFromCnpj(string cnpj)
        {
            try
            {

                using var conexao = fabric.Connect();
                using var reader = fabric.ExecuteCommandReader($"SELECT * FROM COMPANYS WHERE CNPJ = '{cnpj}'", conexao);

                string _cnpj = "";
                string _name = "";
                while (reader.Read())
                {
                    _cnpj = reader["CNPJ"].ToString();
                    _name = reader["COMPANY_NAME"].ToString();
                }


                if (_cnpj != "")
                {
                    Store company = new Store() { Cnpj = _cnpj, Name = _name };
                    return company;
                }
                else
                {
                    return new Store();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CheckExist(string cnpj)
        {
            try
            {
                using var conexao = fabric.Connect();
                using var reader = fabric.ExecuteCommandReader($"SELECT COMPANY_NAME FROM COMPANYS WHERE CNPJ = '{cnpj}'", conexao);

                string name = "";
                while (reader.Read())
                {
                    name = reader["COMPANY_NAME"].ToString();
                }

                if (name != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                
            }



        }
    }
}
