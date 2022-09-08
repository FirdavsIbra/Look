using Look.Domain.Entities.Commons;

namespace Look.Domain.Entities.Customers
{
    public class Customer : Auditable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
