using DG.Tweening;
using Other;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InventoryBased {
  public class InventorySlot : MonoBehaviour, IDropHandler {
    [SerializeField]
    private Constants.InventoryType _type;
    [SerializeField]
    private Transform parentContainter;

    public void OnDrop(PointerEventData eventData) {
      InventoryItem item = InventoryItem.DragItem;
      if (parentContainter.childCount > 0) return;

      Transform it = item.transform;
      it.SetParent(parentContainter);
      it.DOLocalMove(Vector3.zero, .1f);
      
      InventoryTransfer.ChangeInventoryItemType(ref item, _type);
    }
  }
}