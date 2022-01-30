using UnityEngine;
using UnityEngine.EventSystems;

namespace InventoryBased {
  public class InventorySlot : MonoBehaviour, IDropHandler {
    public void OnDrop(PointerEventData eventData) {
      InventoryItem item = InventoryItem.dragItem;
      if (!item && transform.childCount >0) return;
      
      item.transform.SetParent(transform);
      item.transform.localPosition = Vector3.zero;
    }
  }
}