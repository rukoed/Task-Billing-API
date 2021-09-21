using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using PayPal.Api;
using Test.Common;
using Test.Interfaces;
using Test.Models;

namespace Test.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepo;

        public OrdersController(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<Result> GetByID(int id)
        {
            var res = new Result();
            var orderData = await _orderRepo.GetByIdAsync(id);

            switch (orderData.PaymentGatewayId)
            {
                case Gateway.PayPal:
                {
                    var apiContext = PaypalConfiguration.GetAPIContext(orderData.ClientId, orderData.ClientSecret);

                    try
                    {
                        //A resource representing a Payer that funds a payment Payment Method as paypal
                        //Payer Id will be returned when payment proceeds or click to pay
                        var payerId = orderData.Id.ToString();

                        // This function executes after receiving all parameters for the payment

                        var guid = Guid.NewGuid().ToString();
                        var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);

                        //If executed payment failed then we will show payment failure message to user
                        if (executedPayment.state.ToLower() != "approved")
                        {
                            res.Status = new HttpStatusCodeResult(400);
                            return res;
                        }
                    }
                    catch (Exception)
                    {
                        res.Status = new HttpStatusCodeResult(400);
                        return res;
                    }

                    //on successful payment, show success page to user.
                    res.Status = new HttpStatusCodeResult(200);
                    res.Receipt = await _orderRepo.SaveOrderAsync(orderData);
                    return res;
                }

                case Gateway.SamsungPay:
                    break;
            }

            res.Status = new HttpStatusCodeResult(502);
            return res;
        }

        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution {payer_id = payerId};
            var payment = new Payment {id = paymentId};
            return payment.Execute(apiContext, paymentExecution);
        }
    }
}