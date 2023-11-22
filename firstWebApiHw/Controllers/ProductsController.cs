using AutoMapper;
using DTO;
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
        IMapper _mapper;
        public ProductsController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> Get(string? desc, int? minPrice, int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            List<Product> products = await _productService.getAllProducts(desc,  minPrice,maxPrice,  categoryIds);
            List<ProductDto> productsDtos = _mapper.Map<List<Product>, List<ProductDto>>(products);
            return products != null ? Ok(productsDtos) : BadRequest();
        }

    }
}
