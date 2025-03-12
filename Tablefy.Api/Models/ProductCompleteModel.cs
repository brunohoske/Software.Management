using Tablefy.Api.Entities;

namespace Tablefy.Api.Models
{
    public class ProductCompleteModel : ProductSimpleModel
    {
        public ProductExtrasModel Extras { get; set; }
        
    }
}
