using UnityEngine;

namespace InventoryBased {
  public class Inventory : MonoBehaviour {
    protected InventoryContainer Container;
    
    protected void AddItem(InventoryItem item) {
      InventoryManager.AddItem(ref Container, item);
    }

    protected void RemoveItemByIndex(int index) {
      InventoryManager.RemoteItem(ref Container, index);
    }
  }
}