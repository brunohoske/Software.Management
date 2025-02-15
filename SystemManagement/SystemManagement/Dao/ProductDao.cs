using MySql.Data.MySqlClient;
using System.Globalization;
using SystemManagement.Data;
using SystemManagement.Models;

namespace SystemManagement.Dao
{
    public static class ProductDao //: BaseDao
    {
        static MySqlConnection conexao = null;
        static ConnectionFabric fabric = new ConnectionFabric();
        public static List<Product> GetProducts(Store store)
        {
            List<Product> products = new List<Product>();
            try
            {
                using var conexao = fabric.Connect();
                using var reader = fabric.ExecuteCommandReader($"SELECT * FROM PRODUCTS WHERE CNPJ = {store.Cnpj}",conexao);
               while (reader.Read())
                {
                    Product product = new Product();

                    product.Id = reader.GetInt32("IdProduct");
                    product.Name = reader["Product_name"].ToString();
                    product.Value = Convert.ToInt32(reader["PRICE"]);
                    product.Description = reader["DESCRIPTION"].ToString();
                    product.Category = new Category() { IdCategory = int.Parse(reader["IdCategory"].ToString()) };
                    product.Store = new Store() { Name = "McDonalds", Cnpj = reader["CNPJ"].ToString() };
                    product.Kcal = Convert.ToDouble(reader["KCAL"]);
                    product.Image = reader["IMAGE"].ToString();

                    products.Add(product);
                }

                return products;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Product GetProductFromId(int id,string cnpj)
        {
            try
            {
                using var conexao = fabric.Connect();
                using var reader = fabric.ExecuteCommandReader($"SELECT * FROM PRODUCTS WHERE IDPRODUCT = {id} AND CNPJ = '{cnpj}'", conexao);
                Product product = new Product();
                if(reader != null)
                {
                    while (reader.Read())
                    {
                        product.Id = Convert.ToInt32(reader["idproduct"].ToString());
                        product.Name = reader["Product_Name"].ToString();
                        product.Value = Convert.ToInt32(reader["price"]);
                        product.Description = reader["description"].ToString();
                        product.Store = new Store() { Cnpj = reader["cnpj"].ToString() };
                        product.Kcal = Convert.ToDouble(reader["kcal"]);
                        product.Image = reader["image"].ToString();
                        product.Category = new Category() { IdCategory = int.Parse(reader["IDCATEGORY"].ToString()) };
                    }
                }
                else
                {
                    return new Product();
                }
                

                return product;
            }
            catch
            {
                return new Product();
            }
        }

        public static List<Product> GetAcompanhamentos(int id, string cnpj)
        {
            try
            {
                using var conexao = fabric.Connect();
                using var reader = fabric.ExecuteCommandReader($"SELECT p.* FROM products p JOIN products_acompanhamentos pa ON pa.Acompanhamento = p.IDPRODUCT AND pa.CNPJ = p.CNPJ WHERE pa.PRODUCT = {id} AND p.CNPJ = {cnpj}",conexao);

                List<Product> acompanhamentos = new List<Product>();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        var product = new Product();
                        product.Id = Convert.ToInt32(reader["idproduct"].ToString());
                        product.Name = reader["Product_Name"].ToString();
                        product.Value = Convert.ToInt32(reader["price"]);
                        product.Description = reader["description"].ToString();
                        product.Store = new Store() { Cnpj = reader["cnpj"].ToString() };
                        product.Kcal = Convert.ToDouble(reader["kcal"]);
                        product.Image = reader["image"].ToString();
                        product.Category = new Category() { IdCategory = int.Parse(reader["IDCATEGORY"].ToString()) };
                        acompanhamentos.Add(product);
                    }
                    return acompanhamentos;
                }

                return new List<Product>();
            }
            catch { return new List<Product>(); }
        }
    }
}
