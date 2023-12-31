using Catalog.Api.Entities;

namespace Catalog.Api.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsListAsync();
        Task<Product> GetProductByIDAsync(string ID);
        Task<IEnumerable<Product>> GetProductListByNameAsync(string Name);
        Task<IEnumerable<Product>> GetProductListByCategory(string CategoryName);
        Task CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(string  id);
    }
}
