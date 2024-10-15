using MySql.Data.MySqlClient;
using Software.Menu.Models;

namespace Software.Menu.DAL
{
    public class DALCompany
    {

        MySqlConnection conexao = null;
        Database database = new Database();
        public DALCompany()
        {

        }

        public bool CheckExist(string cnpj)
        {
            try
            {
                using var reader = database.ExecuteCommandReader($"SELECT COMPANY_NAME FROM COMPANYS WHERE CNPJ = '{cnpj}'");

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
                database.CloseConnection();
            }



        }

        public Company GetCompanyPerName(string companyName)
        {
            try
            {
                conexao = database.GetConnection();
                using var reader = database.ExecuteCommandReader($"SELECT * FROM COMPANYS WHERE COMPANY_NAME = '{companyName}'");

                string name = "";
                while (reader.Read())
                {
                    name = reader["COMPANY_NAME"].ToString();
                }
                
                
                if (name != "")
                {
                    Company company = new Company(name);
                    return company; 
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
                database.CloseConnection();
            }
        }

        public Company GetCompanyFromCnpj(string cnpj)
        {
            try
            {
             
                conexao = database.GetConnection();
                using var reader = database.ExecuteCommandReader($"SELECT * FROM COMPANYS WHERE CNPJ = '{cnpj}'");

                string _cnpj = "";
                string _name = "";
                while (reader.Read())
                {
                    _cnpj = reader["CNPJ"].ToString();
                    _name = reader["COMPANY_NAME"].ToString();
                }


                if (_cnpj != "")
                {
                    Company company = new Company() { cnpj = _cnpj , Name = _name};
                    return company;
                }
                else
                {
                    return new Company();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
                database.CloseConnection();
                
            }
        }
    }
}

