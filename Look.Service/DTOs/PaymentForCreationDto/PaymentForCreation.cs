using Look.Domain.Enums;

namespace Look.Service.DTOs.PaymentForCreationDto
{
    public class PaymentForCreation
    {
        public PaymentType TypeOfPayment { get; set; }
        public long OrderId { get; set; }
    }
}
