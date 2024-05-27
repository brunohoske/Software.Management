using MySql.Data.MySqlClient;
using Software.Menu.Models;

namespace Software.Menu.DAL
{
    public class DALCompany
    {

        MySqlDataReader reader = null;

        public DALCompany()
        {

        }

        public bool CheckExist(string companyName)
        {
            try
            {
                Database database = new Database();
                reader = database.ExecuteCommandReader($"SELECT COMPANY_NAME FROM COMPANYS WHERE COMPANY_NAME = '{companyName}'", reader);

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



        }

        public Company GetCompanyPerName(string companyName)
        {
            try
            {
                Database database = new Database();
                database.GetConnection();
                reader = database.ExecuteCommandReader($"SELECT * FROM COMPANYS WHERE COMPANY_NAME = '{companyName}'", reader);

                string name = "";
                while (reader.Read())
                {
                    name = reader["COMPANY_NAME"].ToString();
                }
                
                
                if (name != "")
                {
                    Company c = new Company(name);
                    return c; 
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
        } 
    }
}

