using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApiShopSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
             IEnumerable<Category>categories=await _categoryService.Get();
            return categories != null ? Ok(categories) : BadRequest();
        }

      
    }
}
