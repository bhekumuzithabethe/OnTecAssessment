using Microsoft.EntityFrameworkCore;
using OnTecAssessment.Components.Data;
using OnTecAssessment.Components.Domain;

namespace OnTecAssessment.Components.Service
{
    public class ProductService(AppDbContext context) : IProductService
    {
        private readonly AppDbContext _context = context;

        // Get all products including images
        public async Task<IEnumerable<ProductConstract>> GetAllProductsAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Select(p => new ProductConstract
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    Category = p.Category,
                    ProductImage = p.ProductImage // Include image bytes
                })
                .ToListAsync();
        }

        // Get products filtered by category including images
        public async Task<IEnumerable<ProductConstract>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.Category)
                .Select(p => new ProductConstract
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    Category = p.Category,
                    ProductImage = p.ProductImage
                })
                .ToListAsync();
        }

        // Get a single product by ID including image
        public async Task<ProductConstract> GetProductByIdAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {id} not found.");

            return new ProductConstract
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Category = product.Category,
                ProductImage = product.ProductImage
            };
        }

        // Create new product including image
        public async Task CreateProductAsync(CreateProductConstract product)
        {
            var productEntity = new Product
            {
                Name = product.Name,
                Price = product.Price,
                ProductImage = product.ProductImage,
                CategoryId = product.CategoryId
            };

            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();
        }

        // Update existing product including image
        public async Task UpdateProductAsync(UpdateProductConstract product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Id);
            if (existingProduct == null)
                throw new KeyNotFoundException($"Product with ID {product.Id} not found.");

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.ProductImage = product.ProductImage;
            existingProduct.CategoryId = product.CategoryId;

            await _context.SaveChangesAsync();
        }

        // Delete product
        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {id} not found.");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
