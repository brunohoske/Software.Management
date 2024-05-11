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
                reader = database.ExecuteCommandReader($"SELECT NAME FROM EMPRESAS WHERE NAME = '{companyName}'", reader);

                string name = "";
                while (reader.Read())
                {
                    name = reader["name"].ToString();
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
                reader = database.ExecuteCommandReader($"SELECT * FROM EMPRESAS WHERE NAME = '{companyName}'", reader);

                string name = "";
                while (reader.Read())
                {
                    name = reader["name"].ToString();
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

