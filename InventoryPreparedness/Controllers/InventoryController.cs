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
      List<Inventory> model = _db.Inventories
                            .Include(inventory => inventory.Category)
                            .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View();
    }
    }
  }
}