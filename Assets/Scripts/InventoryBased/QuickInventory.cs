namespace InventoryBased {
  public delegate void AddItemToQuickInventory(InventoryItem item);
  public delegate void RemoveItemToQuickInventoryByIndex(int index);
  public class QuickInventory : Inventory {
    public static AddItemToQuickInventory OnAddItemToQuickInventory;
    public static RemoveItemToQuickInventoryByIndex OnRemoveItemToQuickInventoryByIndex;

    private void Awake() {
      Container = new InventoryContainer(5);
      SubscribeActions();
    }
    
    private void OnDestroy() {
      UnsubscribeActions();
    }
    
    private void SubscribeActions() {
      OnAddItemToQuickInventory += AddItem;
      OnRemoveItemToQuickInventoryByIndex += RemoveItemByIndex;
    }
    
    private void UnsubscribeActions() {
      OnAddItemToQuickInventory -= AddItem;
      OnRemoveItemToQuickInventoryByIndex -= RemoveItemByIndex;
    }
    
    
  }
}