using Look.Domain.Entities.Commons;
using System.ComponentModel.DataAnnotations;

namespace Look.Domain.Entities.Products
{
    public class Product : Auditable
    {
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }


        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
