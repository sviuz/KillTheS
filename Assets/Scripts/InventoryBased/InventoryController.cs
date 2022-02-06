using Other;

namespace InventoryBased {
  public static  class InventoryController {
    public static void AddItemToList(InventoryItem item) {
      if (item.GetItemType() == Constants.InventoryType.FullInventory) {
        Inventory.instance.Container.AddToFullInventoryItemsCount(item);
      } else {
        Inventory.instance.Container.AddToQuickInventoryItemsCount(item);
      }
    }
    
    public static void ChangeInventoryItemType(ref InventoryItem item, Constants.InventoryType type) {
      item.ChangeInventoryType(type);
      AddItemToList(item);
    }
  }
}