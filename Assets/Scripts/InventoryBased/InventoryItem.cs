using DG.Tweening;
using Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Other.Constants;

namespace InventoryBased {
  public class InventoryItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {
    public static InventoryItem dragItem;
    
    private InventoryType inventoryType;
    private ItemType _itemType;
    private Vector3 itemStartPosition;
    private Image _image;//TODO Set Image On Awake
    private RectTransform rectTransform;
    private Transform itemParent;
    private CanvasGroup canvasGroup;
    private RectTransform dragLayer;
    private bool canDrag = true;
    public InventoryType GetItemType() => inventoryType;

    public ItemType GetType() => _itemType;

    public void ChangeInventoryType(InventoryType type) {
      if (Equals(type, inventoryType)) return;
      
      inventoryType = type;
    }

    private void Awake() {
      rectTransform = GetComponent<RectTransform>();
      canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start() {
      dragLayer = LayerManager.instance.GetRectByTag(TagsEnum.Drag);
    }

    
    public void OnBeginDrag(PointerEventData eventData) {
      dragItem = this;
      itemStartPosition = transform.localPosition;
      itemParent = transform.parent;
      transform.SetParent(dragLayer);
      canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData) {
      var sq = DOTween.Sequence();
      dragItem = null;
      canvasGroup.blocksRaycasts = true;
      if (transform.parent == dragLayer) {
        transform.SetParent(itemParent);
        sq.Append(transform.DOLocalMove(Vector3.zero, .2f)).OnStart(() => { canDrag = false; })
          .OnComplete(() => {
                        canDrag = true;
                        transform.localPosition = itemStartPosition;
                      });
      }
    }

    public void OnDrag(PointerEventData eventData) {
      if (!canDrag) return;

      rectTransform.anchoredPosition += eventData.delta;
    }
  }
}