using System.Threading.Tasks;
using System.Web.Http;
using Test.Interfaces;
using Test.Models;

namespace Test.Controllers
{
    [RoutePrefix("orders")]
    public class OrdersController : ApiController
    {
        private readonly IOrderRepository _orderRepo;

        public OrdersController(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IHttpActionResult> All()
        {
            var result = await _orderRepo.GetAllOrdersAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetByID(int id)
        {
            var result = await _orderRepo.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateOrder([FromBody]Order cart)
        {
            if (cart != null)
            {
                Receipt result = await _orderRepo.SaveOrderAsync(cart);
                if (result != null) return Ok(result);
            }

            return Ok("Nothing changed");
        }

        [HttpPut]
        public async Task<IHttpActionResult> EditOrder(int id, [FromBody]Order cart)
        {
            if (cart != null)
            {
                var result = await _orderRepo.EditOrder(id, cart);
                if (result) return Ok($"order with id: {cart.Id} has been updated to database");
            }

            return Ok("Nothing changed");
        }

        [HttpDelete]
        public void DeleteOrder(int id)
        {
            _orderRepo.DeleteOrder(id);
        }
    }
}