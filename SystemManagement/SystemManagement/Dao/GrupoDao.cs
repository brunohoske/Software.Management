﻿using SystemManagement.Data;
using SystemManagement.Models;

namespace SystemManagement.Dao
{
    public class GrupoDao
    {

        private readonly ConnectionFabric _connectionFabric;
        private readonly CategoryDao _categoryDao;
        private readonly ProductDao _productDao;
        public GrupoDao(ConnectionFabric connectionFabric, CategoryDao categoryDao, ProductDao productDao)
        {
            _connectionFabric = connectionFabric;
            _categoryDao = categoryDao;
            _productDao = productDao;
            //_comboDao = comboDao;
        }

        public List<Grupo> GetGroups(string cnpj)
        {
            List<Grupo> groups = new List<Grupo>();
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM COMBOS WHERE CNPJ = {cnpj}", conexao);
                while (reader.Read())
                {
                    groups.Add(GetGroupFromId(Convert.ToInt32(reader["IDCOMBO"].ToString()), cnpj));
                }

                return groups;
            }
            catch (Exception ex)
            {
                return new List<Grupo>();
            }

        }

        public Grupo GetGroupFromId(int idGroup, string cnpj)
        {
            List<Combo> combos = new List<Combo>();
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM grupos WHERE IDGROUP = {idGroup} AND CNPJ = {cnpj}", conexao);
                Grupo group = new Grupo();
                while (reader.Read())
                {
                    group.Id = reader.GetInt32("idGroup");
                    group.Name = reader.GetString("Group_name");
                    group.Description = reader.GetString("Group_description");
                    group.Products = GetGroupsProducts(group.Id, cnpj);
                    group.ViewName = reader.GetString("viewName");
                    group.Combos = GetGroupsCombos(group.Id,cnpj); 
                }

                return group;
            }
            catch (Exception ex)
            {
                return new Grupo();
            }
        }


        public List<Product> GetGroupsProducts(int idGroup, string cnpj)
        {
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT P.*,gp.price as price_group FROM grupos g JOIN grupos_products gp ON g.IDGROUP = gp.IDGROUP JOIN products p ON gp.IDPRODUCT = p.IDPRODUCT WHERE G.IDGROUP = {idGroup} AND G.CNPJ = '{cnpj}';", conexao);

                List<Product> products = new List<Product>();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product = _productDao.GetProductFromId(Convert.ToInt32(reader["IDPRODUCT"].ToString()), cnpj);
                        product.Value = Convert.ToDecimal(reader["price_group"]);
                        products.Add(product);

                    }
                    return products;
                }

                return new List<Product>();
            }
            catch { return new List<Product>(); }

        }

        public List<Combo> GetGroupsCombos(int idGroup, string cnpj)
        {
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT c.* FROM grupos g JOIN grupos_combos gc ON g.IDGROUP = gc.IDGROUP JOIN combos c ON gc.IDCOMBO = c.IDCOMBO WHERE  g.IDGROUP = {idGroup} AND G.CNPJ = '{cnpj}';", conexao);

                List<Combo> combos = new List<Combo>();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        //combos.Add(_comboDao.GetCombosFromId(Convert.ToInt32(reader["IDCOMBO"].ToString()), cnpj));
                        Combo combo = new Combo();
                        combo.Id = reader.GetInt32("IdCombo");
                        combo.Name = reader["Combo_name"].ToString();
                        combo.Value = Convert.ToInt32(reader["PRICE"]);
                        combo.Description = reader["DESCRIPTION"].ToString();
                        combo.Store = new Store() { Name = "McDonalds", Cnpj = reader["CNPJ"].ToString() };
                        combo.Kcal = Convert.ToDouble(reader["KCAL"]);
                        combo.Image = reader["IMAGE"].ToString();
                        combo.BarCode = reader["BarCode"].ToString();

                    }
                    return combos;
                }

                return new List<Combo>();
            }
            catch { return new List<Combo>(); }
        }

    }
}
