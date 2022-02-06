using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using Other;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InventoryBased {
  public class InventorySlot : MonoBehaviour, IDropHandler {
    [SerializeField]
    private Constants.InventoryType _type;

    public void OnDrop(PointerEventData eventData) {
      InventoryItem item = InventoryItem.dragItem;
      if (!item && transform.childCount > 0) return;

      Transform it = item.transform;
      it.SetParent(transform);
      it.DOLocalMove(Vector3.zero, .1f);
      ChangeInventoryItemType(item);

      print(item.GetItemType());
    }

    private void ChangeInventoryItemType(InventoryItem item) {
      item.ChangeInventoryType(_type);


      bool myTypeItem = item.GetItemType() == Constants.InventoryType.MyInventory;
      List<InventoryItem> addList = myTypeItem
        ? MyInventory.OnGetContainer?.Invoke()._inventoryItems
        : QuickInventory.OnGetContainer?.Invoke()._inventoryItems;
      List<InventoryItem> removeList = myTypeItem
        ? QuickInventory.OnGetContainer?.Invoke()._inventoryItems
        : MyInventory.OnGetContainer?.Invoke()._inventoryItems;
      

      InventoryController.AddItemToList(ref addList, item);
      InventoryController.RemoveItemFromList(ref removeList, item);
    }
  }
}