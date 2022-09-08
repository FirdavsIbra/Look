using Look.Domain.Entities.Commons;
using Look.Domain.Entities.Products;
using System.ComponentModel.DataAnnotations;

namespace Look.Domain.Entities.Categories
{
    public class Category : Auditable
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}