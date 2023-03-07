using System.Collections.Generic;

namespace InventoryPreparedness.Models
{
  public class Category
  {
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public List<Inventory> Inventorys { get; set; }
  }
}