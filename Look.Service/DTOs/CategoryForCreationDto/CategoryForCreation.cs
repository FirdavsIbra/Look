using Look.Domain.Entities.Products;

namespace Look.Service.DTOs.CategoryForCreationDto
{
    public class CategoryForCreation
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
