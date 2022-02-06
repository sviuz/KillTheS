using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryBased {
  [Serializable]
  public class InventoryContainer {
    public static Action<InventoryItem> OnAddItem;
    [SerializeField]
    private  List<InventoryItem> _fullInventoryItems = new List<InventoryItem>();
    [SerializeField]
    private  List<InventoryItem> _quickInventoryItems = new List<InventoryItem>();

    private void Awake() {
      OnAddItem += AddToFullInventoryItemsCount;
    }

    private void OnDestroy() {
      OnAddItem -= AddToFullInventoryItemsCount;
    }

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
  }
}