using MySql.Data.MySqlClient;
using SystemManagement.Data;
using SystemManagement.Models;

namespace SystemManagement.Dao
{
    public class StoreDao
    {
        private readonly ConnectionFabric _connectionFabric;

        public StoreDao(ConnectionFabric connectionFabric)
        {
            _connectionFabric = connectionFabric;
        }
        public Store GetCompanyFromCnpj(string cnpj)
        {
            try
            {

                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM COMPANYS WHERE CNPJ = '{cnpj}'", conexao);

                int id = 0;
                string _cnpj = "";
                string _name = "";
                while (reader.Read())
                {
                    id = int.Parse(reader["IDCOMPANY"].ToString());
                    _cnpj = reader["CNPJ"].ToString();
                    _name = reader["COMPANY_NAME"].ToString();
                }


                if (_cnpj != "")
                {
                    Store company = new Store() { Cnpj = _cnpj, Name = _name, Id = id };
                    return company;
                }
                else
                {
                    return new Store();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool CheckExist(string cnpj)
        {
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT COMPANY_NAME FROM COMPANYS WHERE CNPJ = '{cnpj}'", conexao);

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
                throw;

            }
        }
    }
}
