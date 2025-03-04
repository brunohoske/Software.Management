using SystemManagement.Data;
using SystemManagement.Models;

namespace SystemManagement.Dao
{
    public class IngredientDao
    {
        private readonly ConnectionFabric _connectionFabric;

        public IngredientDao(ConnectionFabric connectionFabric)
        {
            _connectionFabric = connectionFabric;
        }
        public List<Ingredient> GetIngredients(Store store)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM INGREDIENTS WHERE idcompany = {store.Id}",conexao);
                while (reader.Read())
                {
                    Ingredient ingredient = new Ingredient();

                    ingredient.IdIngredient = reader.GetInt32("IdIngredient");
                    ingredient.Name = reader["Name"].ToString();
                    ingredient.Description = reader["Description"].ToString();
                    ingredient.Store = store;

                    ingredients.Add(ingredient);
                }

                return ingredients;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                
            }
        }
        public Ingredient GetIngredientFromId(int id, Store store)
        {
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT * FROM INGREDIENTS WHERE IDINGREDIENT = {id} and idcompany = {store.Id}", conexao);
                Ingredient ingredient = new Ingredient();
                while (reader.Read())
                {
                    ingredient.IdIngredient = Convert.ToInt32(reader["IdIngredient"].ToString());
                    ingredient.Name = reader["Name"].ToString();
                    ingredient.Description = reader["Description"].ToString();
                    ingredient.Store = store;
                }

                return ingredient;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                
            }
        }

        public List<Ingredient> GetProductIngredients(int idProduct,Store store)
        {
            try
            {
                using var conexao = _connectionFabric.Connect();
                using var reader = _connectionFabric.ExecuteCommandReader($"SELECT i.IdIngredient, i.NAME, i.Description,pin.idProduct, i.idcompany FROM ingredients i\r\nJOIN products_ingrdients pin\r\nJOIN products p \r\nON p.IDPRODUCT = pin.idProduct  AND i.IdIngredient = pin.idIngredient\r\nWHERE pin.idproduct = {idProduct}\r\nAND i.idCompany =  {store.Id};",conexao);
                List<Ingredient> ingredients = new List<Ingredient>();
                if(reader.FieldCount == 0)
                {
                    return new();
                }
                while (reader.Read())
                {
                    var ingredient = new Ingredient()
                    {
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),
                        IdIngredient = reader.GetInt32("IdIngredient"),
                        Store = store
                    };
                    ingredients.Add(ingredient);
                }

                return ingredients;
            }
            catch (Exception ex)
            {
                return new List<Ingredient>();
            }
            finally
            {
                
            }
        }
    }

  
}
