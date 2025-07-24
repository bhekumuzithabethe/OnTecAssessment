using System.ComponentModel.DataAnnotations;
namespace OnTecAssessment.Components.Domain
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category Name is required.")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public List<Product>? Products { get; set; }
    }
}