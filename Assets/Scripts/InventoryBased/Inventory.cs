using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InventoryBased {
  public class Inventory : MonoBehaviour, IDropHandler {
    protected List<InventoryItem> _inventoryList;
    protected int maxListCounter = 32;


    public virtual void OnDrop(PointerEventData data) {
      
    }
  }
}