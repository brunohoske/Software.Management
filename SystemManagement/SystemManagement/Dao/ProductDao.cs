using SystemManagement.Data;
using SystemManagement.Models;


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
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM PRODUCTS WHERE IDCOMPANY =  {store.Id}",conexao);
               while (reader.Read())
               {
                    products.Add(GetProductFromId(Convert.ToInt32(reader["idproduct"].ToString()), store));
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
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM COMBOS WHERE  IDCOMPANY = {store.Id}", conexao);
                while (reader.Read())
                {
                    Combo combo = new Combo();
                    combo.Id = reader.GetInt32("IdCombo");
                    combo.Name = reader["Combo_name"].ToString();
                    combo.Value = Convert.ToDecimal(reader["PRICE"]);
                    combo.Description = reader["COMBO_DESCRIPTION"].ToString();
                    combo.Store = store;
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

        public IEnumerable<Product> GetProductsFromOrder(int orderId, Store store) 
        {
            using var conexao = _connectionFabric.Connect();
            using var reader = _connectionFabric.ExecuteCommandReader($"SELECT p.*, od.note,od.price as PayValue FROM order_details od " +
                $"inner join products p on od.idproduct = p.idproduct where idorder = {orderId}", conexao);
            List<Product> products = new List<Product>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = Convert.ToInt32(reader["idproduct"].ToString());
                    product.Name = reader["Product_Name"].ToString();
                    product.Value = Convert.ToDecimal(reader["PayValue"]);
                    product.Description = reader["description"].ToString();
                    product.DiscountPercentual = Convert.ToDecimal(reader["DISCOUNT_PERCENTUAL"]);
                    product.DiscountPrice = Convert.ToDecimal(reader["DISCOUNT_PRICE"]);
                    product.Store = store;
                    product.Kcal = Convert.ToDouble(reader["kcal"]);
                    product.Image = reader["image"].ToString();
                    product.Category = new Category() { IdCategory = int.Parse(reader["IDCATEGORY"].ToString()) };
                    product.BarCode = reader["BarCode"].ToString();
                    product.Acompanhamentos = GetAcompanhamentos(product.Id, store);
                    product.CategoriesRecommended = _categoryDao.GetCategoriesRecommended(product, store);
                    product.Ingredients = _ingredientDao.GetProductIngredients(product.Id, store);
                    product.Note = reader["Note"].ToString();
                    foreach (var category in product.CategoriesRecommended)
                    {
                        category.Products = _categoryDao.GetProductCategories(store, category.IdCategory);
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
        public Product GetProductFromId(int id,Store store)
        {
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM PRODUCTS WHERE IDPRODUCT = {id} AND IDCOMPANY = {store.Id}", conexao);
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
                        product.Store = store;
                        product.Kcal = Convert.ToDouble(reader["kcal"]);
                        product.Image = reader["image"].ToString();
                        product.Category = new Category() { IdCategory = int.Parse(reader["IDCATEGORY"].ToString()) };
                        product.BarCode = reader["BarCode"].ToString();
                        product.Acompanhamentos = GetAcompanhamentos(product.Id, store);
                        product.CategoriesRecommended = _categoryDao.GetCategoriesRecommended(product, store);
                        product.Ingredients = _ingredientDao.GetProductIngredients(product.Id, store);
                        foreach (var category in product.CategoriesRecommended)
                        {
                            category.Products = _categoryDao.GetProductCategories(store, category.IdCategory);
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

        public List<Product> GetAcompanhamentos(int id, Store store)
        {
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT p.* FROM products p JOIN products_acompanhamentos pa ON pa.Acompanhamento = p.IDPRODUCT AND p.idCompany = p.idCompany WHERE pa.PRODUCT = {id} AND p.IDCOMPANY = {store.Id}",conexao);

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
                        product.Store = store;
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
