using Look.Domain.Entities.Configurations;
using Look.Service.DTOs.CustomerForCreationDto;
using Look.Service.DTOs.OrderForCreationDto;
using Look.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Look.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _orderService.GetAllAsync(@params));

        [HttpGet("{Id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute(Name = "Id")] long id)
            => Ok(await _orderService.GetAsync(p => p.Id == id));
        [HttpPost]
        public async Task<IActionResult> AddAsync(OrderForCreation dto)
            => Ok(await _orderService.AddAsync(dto));

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute(Name = "Id")] long id, OrderForCreation dto)
            => Ok(await _orderService.UpdateAsync(id, dto));

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "Id")] long id)
            => Ok(await _orderService.DeleteAsync(p => p.Id == id));
    }
}
