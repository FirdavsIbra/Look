using Look.Domain.Entities.Configurations;
using Look.Domain.Entities.Products;
using Look.Service.DTOs.ProductForCreationDto;
using Look.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Look.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _productService.GetAllAsync(@params));

        [HttpGet("{Id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute(Name = "Id")] long id)
            => Ok(await _productService.GetAsync(p => p.Id == id));

        [HttpPost]
        public async Task<ActionResult<Product>> AddAsync(ProductForCreation dto)
            => Ok(await _productService.AddAsync(dto));

        [HttpPut("{Id}")]
        public async Task<ActionResult<Product>> UpdateAsync([FromRoute(Name = "Id")] long id, ProductForCreation dto)
            => Ok(await _productService.UpdateAsync(id, dto));

        [HttpDelete("{Id}")]
        public async Task<ActionResult<bool>> DeleteAsync([FromRoute(Name = "Id")] long id)
            => Ok(await _productService.DeleteAsync(p => p.Id == id));
    }
}
