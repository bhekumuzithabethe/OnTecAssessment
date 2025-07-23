using OnTecAssessment.Components.Domain;

namespace OnTecAssessment.Components.Service
{
    public interface IProductService
    {
        Task<IEnumerable<ProductConstract>> GetProductsByCategoryIdAsync(int categoryId);
        Task<IEnumerable<ProductConstract>> GetAllProductsAsync();
        Task<ProductConstract> GetProductByIdAsync(int id);
        Task CreateProductAsync(CreateProductConstract product);
        Task UpdateProductAsync(UpdateProductConstract product);
        Task DeleteProductAsync(int id);
    }
}
