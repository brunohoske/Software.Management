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


        public bool CheckStoreExists(string cnpj)
        {
            using var conexao = _connectionFabric.Connect();
            using var cmd = conexao.CreateCommand();
            cmd.CommandText = $"SELECT CNPJ FROM Companys WHERE cnpj = '{cnpj}' LIMIT 1";
            var result = cmd.ExecuteScalar();
            

            if (result != null)
            {
                var exist = result.ToString();
                if(exist == cnpj)
                {
                    return true;
                }
               
            }
            return false;
        }

        public Store GetCompanyFromCnpj(string cnpj)
        {
            try
            {

                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM COMPANYS WHERE CNPJ = '{cnpj}'", conexao);

                Store store = new Store();
                while (reader.Read())
                {
                    store.Id = int.Parse(reader["IDCOMPANY"].ToString());
                    store.Cnpj = reader["CNPJ"].ToString();
                    store.Name = reader["COMPANY_NAME"].ToString();
                    store.Image = reader["IMAGE"].ToString();
                    store.Banner = reader["Banner"].ToString();

                }
                if (store.Cnpj != "")
                {
                    return store;
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
