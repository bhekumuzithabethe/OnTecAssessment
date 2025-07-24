using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace OnTecAssessment.Components.Domain
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Name is required.")]
        public string Name { get; set; } = string.Empty;

        [Precision(18, 2)] 
        public decimal Price { get; set; }
        public byte[]? ProductImage { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}