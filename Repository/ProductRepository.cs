using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        SuperMarket214338766Context _superMarketContext;

        public ProductRepository(SuperMarket214338766Context superMarketContext)
        {
            _superMarketContext = superMarketContext;

        }
        public async Task<IEnumerable<Product>> getAllProducts()
        {
            return await _superMarketContext.Products.ToListAsync();
        }


    }
}
