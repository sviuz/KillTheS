using DG.Tweening;
using Other;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InventoryBased {
  public class InventorySlot : MonoBehaviour, IDropHandler {
    private Data.InventoryType _type;
    public void OnDrop(PointerEventData eventData) {
      InventoryItem item = InventoryItem.dragItem;
      if (!item && transform.childCount >0) return;

      Transform it = item.transform; 
      it.SetParent(transform);
      it.DOLocalMove(Vector3.zero, .1f);

      if (_type == Data.InventoryType.QuickInventory) {
        item.ChangeInventoryType(Data.InventoryType.MyInventory);
        
      } else {
        item.ChangeInventoryType(Data.InventoryType.MyInventory);
      }
    }
  }
}