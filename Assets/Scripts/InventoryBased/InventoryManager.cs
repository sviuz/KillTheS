using System;

namespace InventoryBased {
  public static  class InventoryManager {
    public static Action OnOpenInventory;
    public static Action OnHideInventory;
    public static void AddItem(ref InventoryContainer container, InventoryItem item) {
      if (container._maxListCount >= container._inventoryItems.Count) return;
      
      container._inventoryItems.Add(item);
    }

    public static void RemoteItem(ref InventoryContainer container, int index) {
      if (container._inventoryItems[index] == null) return;

      container._inventoryItems.RemoveAt(index);
    }
  }
}