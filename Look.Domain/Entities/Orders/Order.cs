using Look.Domain.Entities.Commons;
using Look.Domain.Entities.Customers;

namespace Look.Domain.Entities.Orders
{
    public class Order : Auditable
    {
        public decimal TotalPrice { get; set; }
        public bool IsPaid { get; set; }

        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        public long DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
    }
}
