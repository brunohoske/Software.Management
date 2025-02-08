using MySql.Data.MySqlClient;
using SystemManagement.Data;
using SystemManagement.Models;

namespace SystemManagement.Dao
{
    public static class IngrdientDao
    {
        static MySqlConnection conexao = null;
        static ConnectionFabric fabric = new ConnectionFabric();

        public static List<Ingredient> GetIngredients(string cnpj)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            try
            {
                using var reader = fabric.ExecuteCommandReader($"SELECT * FROM INGREDIENTS WHERE CNPJ = {cnpj}");
                while (reader.Read())
                {
                    Ingredient ingredient = new Ingredient();

                    ingredient.IdIngredient = reader.GetInt32("IdIngredient");
                    ingredient.Name = reader["Name"].ToString();
                    ingredient.Description = reader["Description"].ToString();

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
                fabric.CloseConnection();
            }
        }
        public static Ingredient GetIngredientFromId(int id, string cnpj)
        {
            try
            {
                using var reader = fabric.ExecuteCommandReader($"SELECT * FROM INGREDIENTS WHERE IDINGREDIENT = {id} and CNPJ = '{cnpj}'");
                Ingredient ingredient = new Ingredient();
                while (reader.Read())
                {
                    ingredient.IdIngredient = Convert.ToInt32(reader["IdIngredient"].ToString());
                    ingredient.Name = reader["Name"].ToString();
                    ingredient.Description = reader["Description"].ToString();
                }

                return ingredient;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                fabric.CloseConnection();
            }
        }

        public static List<Ingredient> GetProductIngredients(int idProduct,string cnpj)
        {
            try
            {
                using var reader = fabric.ExecuteCommandReader($"SELECT i.IdIngredient, i.NAME, i.Description,pin.idProduct, i.Cnpj FROM ingredients i\r\nJOIN products_ingrdients pin\r\nJOIN products p \r\nON p.IDPRODUCT = pin.idProduct  AND i.IdIngredient = pin.idIngredient\r\nWHERE pin.idproduct = {idProduct}\r\nAND pin.CNPJ = '{cnpj}';");
                List<Ingredient> ingredients = new List<Ingredient>();
                while (reader.Read())
                {
                    var ingredient = new Ingredient()
                    {
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),
                        IdIngredient = reader.GetInt32("IdIngredient"),
                        Cnpj = reader["Cnpj"].ToString()
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
                fabric.CloseConnection();
            }
        }
    }

  
}
