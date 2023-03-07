using Microsoft.AspNetCore.Mvc;

namespace InventoryPreparedness.Controllers
{
  public class HomeController: Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}