using Look.Domain.Entities.Configurations;
using Look.Service.DTOs.CategoryForCreationDto;
using Look.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Look.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesContoller : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesContoller(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _categoryService.GetAllAsync(@params));

        [HttpGet("{Id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute(Name = "Id")] long id)
            => Ok(await _categoryService.GetAsync(p => p.Id == id));

        [HttpPost]
        public async Task<IActionResult> AddAsync(CategoryForCreation dto)
            => Ok(await _categoryService.AddAsync(dto));

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute(Name = "Id")] long id, CategoryForCreation dto)
            => Ok(await _categoryService.UpdateAsync(id, dto));

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "Id")] long id)
            => Ok(await _categoryService.DeleteAsync(p => p.Id == id));
    }
}
