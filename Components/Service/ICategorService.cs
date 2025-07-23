using OnTecAssessment.Components.Domain;

namespace OnTecAssessment.Components.Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryConstract>> GetAllCategoriesAsync();
        Task<CategoryConstract?> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(CreateCategoryConstract category);
        Task UpdateCategoryAsync(UpdateCategoryConstract category);
        Task DeleteCategoryAsync(int id);
    }
}
