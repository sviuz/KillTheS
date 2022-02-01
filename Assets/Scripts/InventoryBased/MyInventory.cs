﻿namespace InventoryBased {
  public class MyInventory : Inventory  {
    private void Awake() {
      Container = new InventoryContainer(5);
      SubscribeActions();
    }
    
    private void OnDestroy() {
      UnsubscribeActions();
    }
    
    private void SubscribeActions() {
      OnAddItemToInventory += AddItem;
      OnRemoveItemToInventoryByIndex += RemoveItemByIndex;
      InventoryController.OnOpenInventory += OpenQuickInventory;
      InventoryController.OnHideInventory += HideQuickInventory;
    }
    
    private void UnsubscribeActions() {
      OnAddItemToInventory -= AddItem;
      OnRemoveItemToInventoryByIndex -= RemoveItemByIndex;
      InventoryController.OnOpenInventory -= OpenQuickInventory;
      InventoryController.OnHideInventory -= HideQuickInventory;
    }

    protected override void AddItem(InventoryItem item) {
      base.AddItem(item);
      print("Quick Inventory Add Item");
    }

    protected override void RemoveItemByIndex(int index) {
      base.RemoveItemByIndex(index);
      print("Quick Inventory Add Item");
    }

    private void OpenQuickInventory() {
      _canvasGroup.blocksRaycasts = true;
    }

    private void HideQuickInventory() {
      _canvasGroup.blocksRaycasts = false;
    }
  }
}