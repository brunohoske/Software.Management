using MySql.Data.MySqlClient;
using SystemManagement.Data;
using SystemManagement.Models;

namespace SystemManagement.Dao
{
    public class CategoryDao
    {
        private readonly ConnectionFabric _connectionFabric;
        private readonly IngredientDao _ingredientDao;
        public CategoryDao(ConnectionFabric connectionFabric, IngredientDao ingredientDao)
        {
            _connectionFabric = connectionFabric;
            _ingredientDao = ingredientDao;
        }
        

        public List<Category> GetCategories(Store store)
        {
            List<Category> categories = new List<Category>();
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM CATEGORIES WHERE CNPJ = {store.Cnpj}", conexao);
                while (reader.Read())
                {
                    Category category = new Category();

                    category.Name = reader["Name"].ToString();
                    category.Description = reader["Description"].ToString();
                    category.IdCategory = int.Parse(reader["IdCategory"].ToString());
                    category.Products = GetProductCategories(store.Cnpj, category.IdCategory);
                    category.IsDisplay = Convert.ToInt16(reader["DisplayMainPage"]);
                    category.Products =GetProductCategories(store.Cnpj, category.IdCategory);
                    categories.Add(category);
                }

                return categories;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Category> GetCategoriesRecommended(Product product, string cnpj)
        {
            List<Category> categories = new List<Category>();
            try
            {
                if(product is Combo combo)
                {
                    using var conexao = _connectionFabric.Connect();
                    using var reader = _connectionFabric.ExecuteCommandReader($"SELECT C.* FROM combos co JOIN combos_recommendations cr ON co.idcombo = cr.idcombo JOIN categories C ON C.IDCATEGORY = cr.IDCATEGORY WHERE cr.idcombo = {product.Id} and co.cnpj = '{cnpj}';", conexao);
                    while (reader.Read())
                    {
                        Category category = new Category();

                        category.Name = reader["Name"].ToString();
                        category.Description = reader["Description"].ToString();
                        category.IdCategory = int.Parse(reader["IdCategory"].ToString());
                        category.Products = GetProductCategories(cnpj, category.IdCategory);
                        //category.Combos = GetComboCategories(cnpj, category.IdCategory);
                        category.IsDisplay = Convert.ToInt16(reader["DisplayMainPage"]);
                        categories.Add(category);

                    }
                    
                }
                else{
                    using var conexao = _connectionFabric.Connect();
                    using var reader = _connectionFabric.ExecuteCommandReader($"SELECT C.* FROM products p JOIN products_recommendations pr ON p.IDPRODUCT = pr.IDPRODUCT JOIN categories C ON C.IDCATEGORY = pr.IDCATEGORY WHERE pr.idproduct = {product.Id} and pr.cnpj = '{cnpj}';", conexao);
                    while (reader.Read())
                    {
                        Category category = new Category();

                        category.Name = reader["Name"].ToString();
                        category.Description = reader["Description"].ToString();
                        category.IdCategory = int.Parse(reader["IdCategory"].ToString());
                        category.Products = GetProductCategories(cnpj, category.IdCategory);
                        //category.Combos = GetComboCategories(cnpj, category.IdCategory);
                        category.IsDisplay = Convert.ToInt16(reader["DisplayMainPage"]);
                        categories.Add(category);

                    }
                }

               

                return categories;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Product> GetProductCategories(string cnpj, int idCategory)
        {
            List<Product> products = new List<Product>();
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT p.* FROM  products_categories pc JOIN products p ON pc.PRODUCT = p.IDPRODUCT JOIN categories c ON pc.CATEGORY = c.IDCATEGORY WHERE c.idcategory = {idCategory} AND p.CNPJ = '{cnpj}';", conexao);
                while (reader.Read())
                {
                    Product product = new Product();

                    product.Id = reader.GetInt32("IdProduct");
                    product.Name = reader["Product_name"].ToString();
                    product.Value = Convert.ToDecimal(reader["PRICE"]);
                    product.Description = reader["DESCRIPTION"].ToString();
                    product.DiscountPercentual = Convert.ToDecimal(reader["DISCOUNT_PERCENTUAL"]);
                    product.DiscountPrice = Convert.ToDecimal(reader["DISCOUNT_PRICE"]);
                    product.Category = new Category() { IdCategory = int.Parse(reader["IdCategory"].ToString()) };
                    product.Store = new Store() { Name = "McDonalds", Cnpj = reader["CNPJ"].ToString() };
                    product.Kcal = Convert.ToDouble(reader["KCAL"]);
                    product.Image = reader["IMAGE"].ToString();
                    product.Ingredients = _ingredientDao.GetProductIngredients(product.Id, cnpj);
                    products.Add(product);
                }

                foreach (var combo in GetComboCategories(cnpj, idCategory))
                {
                    combo.Ingredients = new();
                    products.Add(combo);
                }

                return products;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        public List<Product> GetComboCategories(string cnpj, int idCategory)
        {
            List<Product> combos = new List<Product>();
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT C.* FROM combos C JOIN combos_categories CC ON C.IDCOMBO = CC.IDCOMBO JOIN categories CA ON CA.IDCATEGORY = CC.IDCATEGORY WHERE CA.IDCATEGORY = {idCategory} AND CA.CNPJ = '{cnpj}';", conexao);
                while (reader.Read())
                {
                    Combo combo = new Combo();

                    combo.Id = reader.GetInt32("IdCombo");
                    combo.Name = reader["Combo_name"].ToString();
                    combo.Value = Convert.ToDecimal(reader["PRICE"]);
                    combo.Description = reader["COMBO_DESCRIPTION"].ToString();
                    combo.Store = new Store() { Name = "McDonalds", Cnpj = reader["CNPJ"].ToString() };
                    combo.Kcal = Convert.ToDouble(reader["KCAL"]);
                    combo.Image = reader["IMAGE"].ToString();
                    combo.BarCode = reader["BarCode"].ToString();

                    combos.Add(combo);
                }

                return combos;
            }
            catch (Exception ex)
            {
                return null;
            }

        }



    }
}
