using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace InventoryBased {
  public class QuickInventory : Inventory {
    private void Awake() {
      _inventoryList = new List<InventoryItem>();
      maxListCounter = 5;
    }

    public override void OnDrop(PointerEventData data) {
      base.OnDrop(data);
      
    }
  }
}