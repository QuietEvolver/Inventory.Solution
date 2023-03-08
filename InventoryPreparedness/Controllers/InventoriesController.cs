using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using InventoryPreparedness.Models;
using System.Collections.Generic;
using System.Linq;

namespace InventoryPreparedness.Controllers
{
  public class InventoriesController : Controller
  {
    private readonly InventoryPreparednessContext _db;

    public InventoriesController(InventoryPreparednessContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Inventory> model = _db.Inventories.Include(inventory => inventory.Category).ToList();
      // put all on one line: no diff
      // adding ViewBag: testing to see if verbiage bleeds onto other htmls in _Layout
      ViewBag.PageTitle = "Stay Prepped! View All";
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Inventory inventory)
    {
      if (inventory.CategoryId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Inventories.Add(inventory);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Inventory thisInventory = _db.Inventories
                          .Include(inventory => inventory.Category)
                          .FirstOrDefault(inventory => inventory.InventoryId == id);
      return View(thisInventory);
    }

    public ActionResult Edit(int id)
    {
      Inventory thisInventory = _db.Inventories.FirstOrDefault(inventory => inventory.InventoryId == id);
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View(thisInventory);
    }

    [HttpPost]
    public ActionResult Edit(Inventory inventory)
    {
      _db.Inventories.Update(inventory);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Inventory thisInventory = _db.Inventories.FirstOrDefault(inventory => inventory.InventoryId == id);
      return View(thisInventory);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Inventory thisInventory = _db.Inventories.FirstOrDefault(inventory => inventory.InventoryId == id);
      _db.Inventories.Remove(thisInventory);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}