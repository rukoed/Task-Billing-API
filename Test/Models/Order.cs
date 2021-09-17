namespace Test.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string OrderNumber { get; set; }

        public int UserId { get; set; }

        public decimal Amount { get; set; }

        public Gateway PaymentGatewayId { get; set; }

        public string OptionalDescription { get; set; }
    }
}