using Microsoft.EntityFramweorkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Inventory.Models;

namespace Inventory.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly InventoryContext _db;

    public CategoriesController(InventoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Category> model = _db.Categories.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Category category)
    {
      _db.Categories.Add(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Category thisCategory= _db.Categories
                                  .Include(thisCategory => thisCategory.Items)
                                  .FirstOrDefault(thisCategory => thisCategory.CategoryID == id);
      return View(thisCategory);
    }

    public ActionResult Edit(int id)
    {
      Category thisCategory = _db.Categories.FirstOrDefault(thisCategory => thisCategory.CategoryId == id);
      return View(thisCategory);
    }
  }
}