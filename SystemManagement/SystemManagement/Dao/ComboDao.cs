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


        public List<Combo> GetCombos(string cnpj)
        {
            List<Combo> combos = new List<Combo>();
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM COMBOS WHERE CNPJ = {cnpj}", conexao);
                while (reader.Read())
                {
                   combos.Add(GetCombosFromId(Convert.ToInt32(reader["IDCOMBO"].ToString()), cnpj));
                }

                return combos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Combo GetCombosFromId(int IdCombo, string cnpj)
        {
            List<Combo> combos = new List<Combo>();
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM COMBOS WHERE IDCOMBO = {IdCombo} AND CNPJ = {cnpj}", conexao);
                Combo combo = new Combo();
                while (reader.Read())
                {
                    
                    combo.Id = reader.GetInt32("IdCombo");
                    combo.Name = reader["Combo_name"].ToString();
                    combo.Value = Convert.ToInt32(reader["PRICE"]);
                    combo.Description = reader["DESCRIPTION"].ToString();
                    combo.Store = new Store() { Name = "McDonalds", Cnpj = reader["CNPJ"].ToString() };
                    combo.Kcal = Convert.ToDouble(reader["KCAL"]);
                    combo.Image = reader["IMAGE"].ToString();
                    combo.BarCode = reader["BarCode"].ToString();
                    combo.Products = GetComboProducts(cnpj, IdCombo);
                    combo.Groups = GetComboGroups(cnpj,IdCombo);
                    //combo.CategoriesRecommended = _categoryDao.GetCategoriesRecommended(combo.Id, store.Cnpj);
                    //foreach (var category in combo.CategoriesRecommended)
                    //{
                    //    category.Products = _categoryDao.GetProductCategories(store.Cnpj, category.IdCategory);
                    //}
                }

                return combo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Product> GetComboProducts(string cnpj, int idCombo)
        {
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT p.* FROM COMBOS C JOIN COMBOS_PRODUCTS CP ON C.IDCOMBO = CP.IDCOMBO JOIN PRODUCTS P ON CP.IDPRODUCT = P.IDPRODUCT WHERE c.IDCOMBO = {idCombo} and c.cnpj = '{cnpj}';", conexao);

                List<Product> products = new List<Product>();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        products.Add(_productDao.GetProductFromId(Convert.ToInt32(reader["IDPRODUCT"].ToString()), cnpj));

                    }
                    return products;
                }

                return new List<Product>();
            }
            catch { return new List<Product>(); }
        }
        public List<Grupo> GetComboGroups(string cnpj, int idCombo)
        {
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT g.* FROM COMBOS C JOIN COMBOS_GRUPOS CG ON C.IDCOMBO = CG.IDCOMBO JOIN GRUPOS G ON CG.IDGRUPO = G.IDGRUPO WHERE C.IDCOMBO = {idCombo} AND c.cnpj = '{cnpj}';", conexao);

                List<Grupo> groups = new List<Grupo>();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        groups.Add(_groupDao.GetGroupFromId(Convert.ToInt32(reader["IDPRODUCT"].ToString()), cnpj));

                    }
                    return groups;
                }

                return new List<Grupo>();
            }
            catch { return new List<Grupo>(); }
        }
    }
  
}
