namespace InventoryPreparedness.Models
{
  public class Inventory
  {
    public int InventoryId { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
  }
}