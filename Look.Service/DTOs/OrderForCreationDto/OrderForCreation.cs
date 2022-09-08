using Look.Domain.Entities.Orders;

namespace Look.Service.DTOs.OrderForCreationDto
{
    public class OrderForCreation
    {
        public decimal TotalPrice { get; set; }
        public bool IsPaid { get; set; }

        public long CustomerId { get; set; }
        public long DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
    }
}
