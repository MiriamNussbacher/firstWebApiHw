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

        // GET: api/<Orderscs>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Orderscs>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Orderscs>
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {
            try
            {
                Order newOrder = await _orderService.createNewOrder(order);
                return newOrder != null ? CreatedAtAction(nameof(Get), new { id = newOrder.UserId }, newOrder) : BadRequest();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // PUT api/<Orderscs>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Orderscs>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
