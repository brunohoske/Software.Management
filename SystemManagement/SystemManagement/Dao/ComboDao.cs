using SystemManagement.Data;
using SystemManagement.DTOs;
using SystemManagement.Models;

namespace SystemManagement.Dao
{
    public class ComboDao
    {
        private readonly ConnectionFabric _connectionFabric;
        private readonly CategoryDao _categoryDao;
        private readonly ProductDao _productDao;
        private readonly GrupoDao _groupDao;
        public ComboDao(ConnectionFabric connectionFabric, CategoryDao categoryDao, ProductDao productDao, GrupoDao grupoDao)
        {
            _connectionFabric = connectionFabric;
            _categoryDao = categoryDao;
            _productDao = productDao;
            _groupDao = grupoDao;
        }


        public List<Combo> GetCombos(Store store)
        {
            List<Combo> combos = new List<Combo>();
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM COMBOS WHERE idCompany = {store.Id}", conexao);
                while (reader.Read())
                {
                   combos.Add(GetCombosFromId(Convert.ToInt32(reader["IDCOMBO"].ToString()), store));
                }

                return combos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Combo GetCombosFromId(int IdCombo, Store store)
        {
            List<Combo> combos = new List<Combo>();
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM COMBOS WHERE IDCOMBO = {IdCombo} AND idcompany = {store.Id}", conexao);
                Combo combo = new Combo();
                while (reader.Read())
                {
                    
                    combo.Id = reader.GetInt32("IdCombo");
                    combo.Name = reader["Combo_name"].ToString();
                    combo.Value = Convert.ToDecimal(reader["PRICE"]);
                    combo.Description = reader["COMBO_DESCRIPTION"].ToString();
                    combo.Store = store;
                    combo.Kcal = Convert.ToDouble(reader["KCAL"]);
                    combo.Image = reader["IMAGE"].ToString();
                    combo.BarCode = reader["BarCode"].ToString();
                    combo.Products = GetComboProducts(store, IdCombo);
                    combo.Groups = GetComboGroups(store, IdCombo);
                    combo.CategoriesRecommended = _categoryDao.GetCategoriesRecommended(combo, store);
                    foreach (var category in combo.CategoriesRecommended)
                    {
                        category.Products = _categoryDao.GetProductCategories(store, category.IdCategory);
                    }
                }

                return combo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Product> GetComboProducts(Store store, int idCombo)
        {
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT p.*,cp.Price as Price_Combo FROM COMBOS C JOIN COMBOS_PRODUCTS CP ON C.IDCOMBO = CP.IDCOMBO JOIN PRODUCTS P ON CP.IDPRODUCT = P.IDPRODUCT WHERE c.IDCOMBO = {idCombo} and c.idCompany = {store.Id};", conexao);

                List<Product> products = new List<Product>();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        //products.Add(_productDao.GetProductFromId(Convert.ToInt32(reader["IDPRODUCT"].ToString()), cnpj));
                        Product product = new Product();
                        product.Id = Convert.ToInt32(reader["idproduct"].ToString());
                        product.Name = reader["Product_Name"].ToString();
                        product.Value = Convert.ToDecimal(reader["price_combo"]);    
                        product.Description = reader["description"].ToString();
                        product.Store = store;
                        product.Kcal = Convert.ToDouble(reader["kcal"]);
                        product.Image = reader["image"].ToString();
                        product.Category = new Category() { IdCategory = int.Parse(reader["IDCATEGORY"].ToString()) };
                        product.BarCode = reader["BarCode"].ToString();
                        product.Acompanhamentos = _productDao.GetAcompanhamentos(product.Id, store);
                        products.Add(product);

                    }
                    return products;
                }

                return new List<Product>();
            }
            catch { return new List<Product>(); }
        }


        public List<Grupo> GetComboGroups(Store store, int idCombo)
        {
            try
            {

                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT g.* FROM COMBOS C JOIN COMBOS_GRUPOS CG ON C.IDCOMBO = CG.IDCOMBO JOIN GRUPOS G ON CG.IDGROUP = G.IDGROUP WHERE C.IDCOMBO = {idCombo} AND c.idcompany = {store.Id};", conexao);

                List<Grupo> groups = new List<Grupo>();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        groups.Add(_groupDao.GetGroupFromId(Convert.ToInt32(reader["IDGROUP"].ToString()), store));

                    }
                    return groups;
                }

                return new List<Grupo>();
            }
            catch { return new List<Grupo>(); }
        }
    }
  
}
