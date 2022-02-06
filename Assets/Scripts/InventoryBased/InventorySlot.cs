using DG.Tweening;
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
      InventoryController.ChangeInventoryItemType(ref item, _type);
    }
  }
}