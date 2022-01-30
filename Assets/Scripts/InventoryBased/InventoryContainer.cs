using System.Collections.Generic;

namespace InventoryBased {
  public class InventoryContainer {
    public int _maxListCount { get; private set; }
    public List<InventoryItem> _inventoryItems;

    public InventoryContainer(int maxListCount) {
      _maxListCount = maxListCount;
      _inventoryItems = new List<InventoryItem>();
    }
  }
}