using Look.Domain.Entities.Configurations;
using Look.Service.DTOs.PaymentForCreationDto;
using Look.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Look.Api.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _paymentService;
        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _paymentService.GetAllAsync(@params));

        [HttpGet("{Id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute(Name = "Id")] long id)
            => Ok(await _paymentService.GetAsync(p => p.Id == id));
        [HttpPost]
        public async Task<IActionResult> AddAsync(PaymentForCreation dto)
            => Ok(await _paymentService.AddAsync(dto));

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute(Name = "Id")] long id, PaymentForCreation dto)
            => Ok(await _paymentService.UpdateAsync(id, dto));

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "Id")] long id)
            => Ok(await _paymentService.DeleteAsync(p => p.Id == id));
    }
}
