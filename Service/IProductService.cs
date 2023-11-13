using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<List<Product>> getAllProducts(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}