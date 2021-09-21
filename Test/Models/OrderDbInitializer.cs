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
                PaymentGatewayId = Gateway.PayPal,
                OptionalDescription = "1111",
                ClientId = "AfhIhRejlBMo0KP0jg5zqK5xX36nf9X_tZ_pQF1VIWRFucbRWrw-A-oF2JIqxRulCaGrIAiUGcxFxHNa",
                ClientSecret = "EEtoQO91JtDuUhGbF0rRwPWG203gTkjOZYhicrJV_VOzwMyjIX19OhcbNXoqK1yyTqDag2o8r3pLicei"
            });
            db.Orders.Add(new Order
            {
                Id = 2,
                OrderNumber = "2",
                UserId = 22,
                Amount = 222,
                PaymentGatewayId = Gateway.PayPal,
                OptionalDescription = "2222",
                ClientId = "AfhIhRejlBMo0KP0jg5zqK5xX36nf9X_tZ_pQF1VIWRFucbRWrw-A-oF2JIqxRulCaGrIAiUGcxFxHNa",
                ClientSecret = "EEtoQO91JtDuUhGbF0rRwPWG203gTkjOZYhicrJV_VOzwMyjIX19OhcbNXoqK1yyTqDag2o8r3pLicei"
            });
            db.Orders.Add(new Order
            {
                Id = 3,
                OrderNumber = "3",
                UserId = 33,
                Amount = 333,
                PaymentGatewayId = Gateway.SamsungPay,
                OptionalDescription = "3333",
                ClientId = "AfhIhRejlBMo0KP0jg5zqK5xX36nf9X_tZ_pQF1VIWRFucbRWrw-A-oF2JIqxRulCaGrIAiUGcxFxHNa",
                ClientSecret = "EEtoQO91JtDuUhGbF0rRwPWG203gTkjOZYhicrJV_VOzwMyjIX19OhcbNXoqK1yyTqDag2o8r3pLicei"
            });

            base.Seed(db);
        }
    }
}