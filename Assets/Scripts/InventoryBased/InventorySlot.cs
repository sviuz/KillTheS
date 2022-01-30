using DG.Tweening;
using Other;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InventoryBased {
  public class InventorySlot : MonoBehaviour, IDropHandler {
    public void OnDrop(PointerEventData eventData) {
      InventoryItem item = InventoryItem.dragItem;
      if (!item && transform.childCount >0) return;

      var sq = DOTween.Sequence();
      Transform it = item.transform; 
      it.SetParent(transform);
      sq.Append(it.DOLocalMove(Vector3.zero, .1f));

      if (item.inventoryType == Data.InventoryType.QuickInventory) {
        item.ChangeInventoryType(Data.InventoryType.FullInventory);
        
      } else {
        item.ChangeInventoryType(Data.InventoryType.FullInventory);
      }
    }
  }
}