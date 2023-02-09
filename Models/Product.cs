#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
namespace ProdCatAssign.Models;


public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "is required")]
    public string Description { get; set; }

    [Required(ErrorMessage = "is required")]
    public int Price { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set;} = DateTime.Now;

    // foreign keys
    
    public List<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
}