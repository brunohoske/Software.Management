using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System.Globalization;
using SystemManagement.Data;
using SystemManagement.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SystemManagement.Dao
{
    public  class ProductDao 
    {

        private readonly ConnectionFabric _connectionFabric;
        private readonly CategoryDao _categoryDao;
        private readonly IngredientDao _ingredientDao;
        public ProductDao(ConnectionFabric connectionFabric,CategoryDao categoryDao,IngredientDao ingrdientDao)
        {
            _connectionFabric = connectionFabric;
            _categoryDao = categoryDao;
            _ingredientDao = ingrdientDao;
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
               foreach(var combo in GetCombos(store) )
               {
                    products.Add(combo);
               }

                return products;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Combo> GetCombos(Store store)
        {
            List<Combo> combos = new List<Combo>();
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM COMBOS WHERE CNPJ = {store.Cnpj}", conexao);
                while (reader.Read())
                {
                    Combo combo = new Combo();
                    combo.Id = reader.GetInt32("IdCombo");
                    combo.Name = reader["Combo_name"].ToString();
                    combo.Value = Convert.ToDecimal(reader["PRICE"]);
                    combo.Description = reader["COMBO_DESCRIPTION"].ToString();
                    combo.Store = new Store() { Cnpj = reader["CNPJ"].ToString() };
                    combo.Ingredients = new();
                    combo.Image = reader["IMAGE"].ToString();
                    combos.Add(combo);
                }

                return combos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Product> GetProductsFromOrder(int orderId, string cnpj) 
        {
            using var conexao = _connectionFabric.Connect();
            using var reader = _connectionFabric.ExecuteCommandReader($"SELECT p.*, od.note FROM order_details od " +
                $"inner join products p on od.idproduct = p.idproduct where idorder = {orderId}", conexao);
            List<Product> products = new List<Product>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = Convert.ToInt32(reader["idproduct"].ToString());
                    product.Name = reader["Product_Name"].ToString();
                    product.Value = Convert.ToDecimal(reader["price"]);
                    product.Description = reader["description"].ToString();
                    product.DiscountPercentual = Convert.ToDecimal(reader["DISCOUNT_PERCENTUAL"]);
                    product.DiscountPrice = Convert.ToDecimal(reader["DISCOUNT_PRICE"]);
                    product.Store = new Store() { Cnpj = reader["cnpj"].ToString() };
                    product.Kcal = Convert.ToDouble(reader["kcal"]);
                    product.Image = reader["image"].ToString();
                    product.Category = new Category() { IdCategory = int.Parse(reader["IDCATEGORY"].ToString()) };
                    product.BarCode = reader["BarCode"].ToString();
                    product.Acompanhamentos = GetAcompanhamentos(product.Id, cnpj);
                    product.CategoriesRecommended = _categoryDao.GetCategoriesRecommended(product, cnpj);
                    product.Ingredients = _ingredientDao.GetProductIngredients(product.Id, cnpj);
                    product.Note = reader["Note"].ToString();
                    foreach (var category in product.CategoriesRecommended)
                    {
                        category.Products = _categoryDao.GetProductCategories(cnpj, category.IdCategory);
                    }
                    products.Add(product);
                }
                return products;
            }
            else
            {
                return Enumerable.Empty<Product>();
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
                        product.Value = Convert.ToDecimal(reader["price"]);  
                        product.Description = reader["description"].ToString();
                        product.DiscountPercentual = Convert.ToDecimal(reader["DISCOUNT_PERCENTUAL"]);
                        product.DiscountPrice = Convert.ToDecimal(reader["DISCOUNT_PRICE"]);
                        product.Store = new Store() { Cnpj = reader["cnpj"].ToString() };
                        product.Kcal = Convert.ToDouble(reader["kcal"]);
                        product.Image = reader["image"].ToString();
                        product.Category = new Category() { IdCategory = int.Parse(reader["IDCATEGORY"].ToString()) };
                        product.BarCode = reader["BarCode"].ToString();
                        product.Acompanhamentos = GetAcompanhamentos(product.Id, cnpj);
                        product.CategoriesRecommended = _categoryDao.GetCategoriesRecommended(product, cnpj);
                        product.Ingredients = _ingredientDao.GetProductIngredients(product.Id, cnpj);
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
                        product.Value = Convert.ToDecimal(reader["price"]);
                        product.Description = reader["description"].ToString();
                        product.DiscountPercentual = Convert.ToDecimal(reader["DISCOUNT_PERCENTUAL"]);
                        product.DiscountPrice = Convert.ToDecimal(reader["DISCOUNT_PRICE"]);
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
