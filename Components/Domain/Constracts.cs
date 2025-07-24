using System.ComponentModel.DataAnnotations;

namespace OnTecAssessment.Components.Domain
{
    public class CreateCategoryConstract
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
    public class CreateProductConstract
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public byte[]? ProductImage { get; set; }

        public int CategoryId { get; set; }
        [Required]
        public Category? Category { get; set; }
    }

    public class UpdateCategoryConstract
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
    public class UpdateProductConstract
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public byte[]? ProductImage { get; set; }

        public int CategoryId { get; set; }
    }
    
    public class CategoryConstract
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
    public class ProductConstract
    {
        [Required]  
        public int Id { get; set; }
        [Required]              
        public string Name { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public byte[]? ProductImage { get; set; }

        public Category? Category { get; set; }
    }
}
