using ProdCatAssign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProdCatAssign.Controllers;

public class CategoryController : Controller
{
    private int? uid 
    {
        get 
        {
            return HttpContext.Session.GetInt32("UUID");
        }
    }
    private PNCContext db;
    public CategoryController(PNCContext context)
    {
        db = context;
    }

    [HttpGet("/categories")]
    public IActionResult AllCat()
    {
        // List<Category> allCategories = db.Categories.ToList();

        return New();
    }

    [HttpGet("/categories/new")]
    public IActionResult New()
    {
        List<Category> allCategories= db.Categories.ToList();
        ViewBag.allCategories = allCategories;
        
        return View("Categories");
    }

    [HttpPost("/categories/create")]
    public IActionResult Create(Category newCategory)
    {
        if(ModelState.IsValid)
        {
        // newDish.ChefId = (int)uid;
        db.Add(newCategory);
        db.SaveChanges();

        return RedirectToAction("AllCat");
        }
        ViewBag.allCategories = db.Categories.ToList();
        return New();
    }

    // [HttpGet("")]
    // public IActionResult All()
    // {

    //     return View("Categories", allCategories);
    // }


    [HttpGet("/categories/{oneCategoryId}")]
    public IActionResult GetOneCatgeory(int oneCategoryId)
    {
    Category? category = db.Categories.Include(e => e.ProductCategories).ThenInclude(e => e.Product).FirstOrDefault(d => d.CategoryId == oneCategoryId); 
    ViewBag.allProducts = db.Products.ToList();        
        if (category == null)
        {
            return RedirectToAction("Categories");
        }

        return View("OneCategory", category);
    }
}