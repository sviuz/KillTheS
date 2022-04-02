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

    [SerializeField] private InventoryItem _item;
    public void OnDrop(PointerEventData eventData) {
      InventoryItem item = InventoryItem.DragItem;
      SetObject(item, true);
    }

    public void SetObject(InventoryItem item, bool anim) {
      _item = item;
      if (parentContainter.childCount > 0) return;

      Transform it = item.transform;
      it.SetParent(parentContainter);
      if (anim) {
        it.DOLocalMove(Vector3.zero, .1f);
      } else {
        // it.localPosition = Vector3.zero;
      }
      
      item.ChangeInventoryType(_type);
    }
  }
}