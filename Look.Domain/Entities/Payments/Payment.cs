using Look.Domain.Entities.Commons;
using Look.Domain.Entities.Orders;
using Look.Domain.Enums;

namespace Look.Domain.Entities.Payments
{
    public class Payment : Auditable
    {
        public PaymentType Type { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }

    }
}
