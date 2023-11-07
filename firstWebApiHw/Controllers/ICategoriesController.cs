using Entities;
using Microsoft.AspNetCore.Mvc;

namespace webApiShopSite.Controllers
{
    public interface ICategoriesController
    {
        void Delete(int id);
        Task<IEnumerable<Category>> Get();
        string Get(int id);
        void Post([FromBody] string value);
        void Put(int id, [FromBody] string value);
    }
}