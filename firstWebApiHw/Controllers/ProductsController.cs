using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;



namespace webApiShopSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            IEnumerable<Product> products = await _productService.getAllProducts();
            return products != null ? Ok(products) : BadRequest();
        }

    }
}
