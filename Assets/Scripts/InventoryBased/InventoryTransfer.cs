using System;
using Newtonsoft.Json;
using Other;
using UnityEngine;

namespace InventoryBased {
  public static  class InventoryTransfer {
    private static void AddItemToList(InventoryItem item) {
      if (item.GetItemType() == Constants.InventoryType.FullInventory) {
        Inventory.OnAddToFullInventoryItemsCount?.Invoke(item);
      } else {
        Inventory.OnAddToQuickInventoryItemsCount?.Invoke(item);
      }
    }
    
    public static void ChangeInventoryItemType(ref InventoryItem item, Constants.InventoryType type) {
      item.ChangeInventoryType(type);
      AddItemToList(item);
    }
    
    public static bool RemoveItemFromQuickInv(int index) {
      return Inventory.OnRemoveItemFromQuickList(index);
    }

    public static InventoryContainer GetContainer() {
      string str = PlayerPrefs.GetString(Constants.InventoryType.Inventory.ToString());
      
      return JsonConvert.DeserializeObject<InventoryContainer>(str);
    }

    public static void SaveContainer() {
      InventoryContainer container = GetContainer();
      string json = JsonConvert.SerializeObject(container);
      PlayerPrefs.SetString(Constants.InventoryType.Inventory.ToString(), json);
    }
  }
}