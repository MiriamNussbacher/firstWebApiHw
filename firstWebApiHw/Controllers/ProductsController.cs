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
        public async Task<ActionResult<List<Product>>> Get(string? desc, int? minPrice, int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            List<Product> products = await _productService.getAllProducts(desc,  minPrice,maxPrice,  categoryIds);
            return products != null ? Ok(products) : BadRequest();
        }

    }
}
