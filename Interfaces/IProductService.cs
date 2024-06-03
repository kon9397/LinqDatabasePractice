using LinqDatabasePractice.Models;

namespace LinqDatabasePractice.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<object>> GetProductsAsync();
        Task<object> GetProductAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(int id, Product product);
        Task<bool> DeleteProductAsync(int id);
        bool ProductExists(int id);
    }
}
