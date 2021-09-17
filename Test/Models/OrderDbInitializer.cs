using System.Data.Entity;
using System.Linq;

namespace Test.Models
{
    public class OrderDbInitializer : CreateDatabaseIfNotExists<OrderContext>
    {
        protected override void Seed(OrderContext db)
        {
            var tempVal = db.Orders.ToList();
            if (tempVal.Any()) return;

            db.Orders.Add(new Order
            {   Id = 1,
                OrderNumber = "1",
                UserId = 11,
                Amount = 111,
                PaymentGatewayId = Gateway.GooglePay,
                OptionalDescription = "1111"
            });
            db.Orders.Add(new Order
            {
                Id = 2,
                OrderNumber = "2",
                UserId = 22,
                Amount = 222,
                PaymentGatewayId = Gateway.GooglePay,
                OptionalDescription = "2222"
            });
            db.Orders.Add(new Order
            {
                Id = 3,
                OrderNumber = "3",
                UserId = 33,
                Amount = 333,
                PaymentGatewayId = Gateway.SamsungPay,
                OptionalDescription = "3333"
            });

            base.Seed(db);
        }
    }
}