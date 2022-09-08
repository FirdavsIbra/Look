using Look.Domain.Entities.Configurations;
using Look.Service.DTOs.CategoryForCreationDto;
using Look.Service.DTOs.CustomerForCreationDto;
using Look.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Look.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _customerService.GetAllAsync(@params));

        [HttpGet("{Id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute(Name = "Id")] long id)
            => Ok(await _customerService.GetAsync(p => p.Id == id));

        [HttpPost]
        public async Task<IActionResult> AddAsync(CustomerForCreation dto)
            => Ok(await _customerService.AddAsync(dto));

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute(Name = "Id")] long id, CustomerForCreation dto)
            => Ok(await _customerService.UpdateAsync(id, dto));

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "Id")] long id)
            => Ok(await _customerService.DeleteAsync(p => p.Id == id));
    }
}
