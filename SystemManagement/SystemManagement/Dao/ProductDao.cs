using MySql.Data.MySqlClient;
using System.Globalization;
using SystemManagement.Data;
using SystemManagement.Models;

namespace SystemManagement.Dao
{
    public  class ProductDao 
    {

        private readonly ConnectionFabric _connectionFabric;
        private readonly CategoryDao _categoryDao;
        public ProductDao(ConnectionFabric connectionFabric,CategoryDao categoryDao)
        {
            _connectionFabric = connectionFabric;
           _categoryDao = categoryDao;
        }
        public  List<Product> GetProducts(Store store)
        {

            List<Product> products = new List<Product>();
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM PRODUCTS WHERE CNPJ = {store.Cnpj}",conexao);
               while (reader.Read())
               {
                    products.Add(GetProductFromId(Convert.ToInt32(reader["idproduct"].ToString()), store.Cnpj));
               }

                return products;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Product GetProductFromId(int id,string cnpj)
        {
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM PRODUCTS WHERE IDPRODUCT = {id} AND CNPJ = '{cnpj}'", conexao);
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
                        product.BarCode = reader["BarCode"].ToString();
                        product.Acompanhamentos = GetAcompanhamentos(product.Id, cnpj);
                        product.CategoriesRecommended = _categoryDao.GetCategoriesRecommended(product, cnpj);
                        foreach (var category in product.CategoriesRecommended)
                        {
                            category.Products = _categoryDao.GetProductCategories(cnpj, category.IdCategory);
                        }
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

        public List<Product> GetAcompanhamentos(int id, string cnpj)
        {
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT p.* FROM products p JOIN products_acompanhamentos pa ON pa.Acompanhamento = p.IDPRODUCT AND pa.CNPJ = p.CNPJ WHERE pa.PRODUCT = {id} AND p.CNPJ = {cnpj}",conexao);

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
                        product.BarCode = reader["BarCode"].ToString();
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
