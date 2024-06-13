using LinqDatabasePractice.Models;

namespace LinqDatabasePractice.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> GetProductAsync(int id);
        Task<ProductDTO> CreateProductAsync(ProductDTO productDto);
        Task<bool> UpdateProductAsync(int id, ProductDTO productDto);
        Task<bool> DeleteProductAsync(int id);
        bool ProductExists(int id);
    }
}