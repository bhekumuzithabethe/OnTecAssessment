using Microsoft.EntityFrameworkCore;
using OnTecAssessment.Components.Data;
using OnTecAssessment.Components.Domain;

namespace OnTecAssessment.Components.Service
{
    public class CategoryService(AppDbContext context) : ICategoryService
    {
        private readonly AppDbContext _context = context;

        // Implementing the methods from ICategoryService interface
        public async Task<IEnumerable<CategoryConstract>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryConstract
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
                .ToListAsync();
        }


        public async Task<CategoryConstract?> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }

            return new CategoryConstract
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        public async Task CreateCategoryAsync(CreateCategoryConstract category)
        {
            var entity = new Category
            {
                Name = category.Name,
                Description = category.Description
            };

            _context.Categories.Add(entity);
            await _context.SaveChangesAsync();

            // Optionally update category.Id with generated entity.Id
            category.Id = entity.Id;
        }




        public async Task UpdateCategoryAsync(UpdateCategoryConstract category)
        {
            var existingCategory = await _context.Categories.FindAsync(category.Id);
            if (existingCategory == null)
            {
                throw new KeyNotFoundException($"Category with ID {category.Id} not found.");
            }

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;

            await _context.SaveChangesAsync();
        }
        
        
        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
