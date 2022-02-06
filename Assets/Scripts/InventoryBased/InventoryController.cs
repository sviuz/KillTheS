using System.Collections.Generic;

namespace InventoryBased {
  public static  class InventoryController {
    public static void AddItemToList(ref List<InventoryItem> list, InventoryItem item) {
      if (list.Contains(item)) return;
      
      list.Add(item);
    }

    public static void RemoveItemFromList(ref List<InventoryItem> list, InventoryItem item) {
      if (!list.Contains(item)) return;

      list.Remove(item);
    }
  }
}