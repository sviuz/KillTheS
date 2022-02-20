using System;
using System.Collections.Generic;

namespace InventoryBased {
  [Serializable]
  public class InventoryContainer {
    public  List<InventoryItem> _fullInventoryItems = new List<InventoryItem>();
    public  List<InventoryItem> _quickInventoryItems = new List<InventoryItem>();
    
    public bool QuickListHasItem(InventoryItem item) => _quickInventoryItems.Contains(item);
    public bool FullListHasItem(InventoryItem item) => _fullInventoryItems.Contains(item);
    
    public void AddToFullInventoryItemsCount(InventoryItem item) {
      if (_fullInventoryItems.Contains(item)) return;
      
      _quickInventoryItems.Remove(item);
      _fullInventoryItems.Add(item);
    }
    
    public void AddToQuickInventoryItemsCount(InventoryItem item) {
      if (_fullInventoryItems.Contains(item)) return;
      
      _fullInventoryItems.Remove(item);
      _quickInventoryItems.Add(item);
    }

    public bool RemoveItemFromQuickList(int index) {
      if (!_quickInventoryItems[index]) return false;

      _quickInventoryItems.RemoveAt(index);
      return true;
    }

  }
}