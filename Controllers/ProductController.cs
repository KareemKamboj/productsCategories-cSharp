using ProdCatAssign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProdCatAssign.Controllers;

public class ProductController : Controller
{
    private int? uid 
    {
        get 
        {
            return HttpContext.Session.GetInt32("UUID");
        }
    }
    private PNCContext db;
    public ProductController(PNCContext context)
    {
        db = context;
    }
    [HttpGet("")]
    public IActionResult All()
    {
        // List<Product> allProducts = db.Products.ToList();

        return New();
    }

    [HttpGet("/products/new")]
    public IActionResult New()
    {
        List<Product> allProducts = db.Products.ToList();
        ViewBag.allProducts = allProducts;

        return View("Products");
    }

    [HttpPost("/products/create")]
    public IActionResult Create(Product newProduct)
    {
        if(ModelState.IsValid)
        {
        // newDish.ChefId = (int)uid;
        db.Add(newProduct);
        db.SaveChanges();

        return RedirectToAction("All");
        }
        ViewBag.allProducts = db.Products.ToList();
        return New();
    }

    // [HttpGet("")]
    // public IActionResult All()
    // {

    //     return View("Products", allProducts);
    // }


    [HttpGet("/products/{oneProductId}")]
    public IActionResult GetOneProduct(int oneProductId)
    {
        Product? product = db.Products.Include(e => e.ProductCategories).ThenInclude(e => e.Category).FirstOrDefault(d => d.ProductId == oneProductId); 
    ViewBag.allCategories = db.Categories.ToList();
        if (product == null)
        {
            return RedirectToAction("Products");
        }

        return View("OneProduct", product);
    }

    [HttpPost("/products/relation/{productId}")]
    public IActionResult Relation(ProductCategory newRelation, int productId)
    {
        db.ProductCategories.Add(newRelation);
        db.SaveChanges();
        return RedirectToAction("GetOneProduct", new { oneProductId = productId });
    }
}