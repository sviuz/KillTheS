using System;
using UnityEngine;

namespace InventoryBased {
  public delegate void AddItemToInventory(InventoryItem item);
  public delegate void RemoveItemToInventoryByIndex(int index);
  public class Inventory : MonoBehaviour {
    public AddItemToInventory OnAddItemToInventory;
    public RemoveItemToInventoryByIndex OnRemoveItemToInventoryByIndex;
    

    [SerializeField]
    public CanvasGroup _canvasGroup;
    
    public InventoryContainer Container;

    private void Awake() {
      if (_canvasGroup == null) {
        _canvasGroup = GetComponent<CanvasGroup>();
      }
    }

    protected void SetContainer(InventoryContainer container) {
      Container = container;
    }

    protected virtual void AddItem(InventoryItem item) {
      InventoryController.AddItem(ref Container, item);
    }

    protected virtual void RemoveItemByIndex(int index) {
      InventoryController.RemoteItem(ref Container, index);
    }
  }
}