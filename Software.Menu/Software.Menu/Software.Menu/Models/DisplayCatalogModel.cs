using System.Text.Json.Serialization;

namespace Software.Menu.Models
{
    public class DisplayCatalogModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("products")]
        public List<ProductSimpleModel> Products { get; set; }
    }
}
