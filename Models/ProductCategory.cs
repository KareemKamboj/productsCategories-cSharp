#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace ProdCatAssign.Models;


public class ProductCategory
{
    [Key]
    public int ProductCategoryId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set;} = DateTime.Now;

    //foreign Keys

    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

}