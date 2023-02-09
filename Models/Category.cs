#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;


namespace ProdCatAssign.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "is required")]
    public string Name { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set;} = DateTime.Now;

    // foreign keys
    
    public List<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
}