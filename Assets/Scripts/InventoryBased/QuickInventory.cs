using System;

namespace InventoryBased {
  
  public class QuickInventory : Inventory {
    public static Action<InventoryContainer> OnSetContainer;
    public static Func<InventoryContainer> OnGetContainer;
    
    private InventoryContainer GetContainer() => Container; 

    
    private void Awake() {
      Container = new InventoryContainer(5);
      SubscribeActions();
    }
    
    private void OnDestroy() {
      UnsubscribeActions();
    }
    
    private void SubscribeActions() {
      OnSetContainer += SetContainer;
      OnGetContainer += GetContainer;

    }
    
    private void UnsubscribeActions() {
      OnSetContainer -= SetContainer;
      OnGetContainer -= GetContainer;
    }

    private void OpenQuickInventory() {
      _canvasGroup.blocksRaycasts = true;
    }

    private void HideQuickInventory() {
      _canvasGroup.blocksRaycasts = false;
    }

    
  }
}