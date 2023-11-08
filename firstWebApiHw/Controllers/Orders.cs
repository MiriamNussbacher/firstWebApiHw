using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApiShopSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Orders : ControllerBase
    {
        IOrderService _orderService;

        public Orders(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // POST api/<Orderscs>
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {
            try
            {
                Order newOrder = await _orderService.createNewOrder(order);
                return newOrder != null ? CreatedAtAction(nameof(Get), new { id = newOrder.UserId }, newOrder) :NoContent();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        // GET api/<Orderscs>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }

}
