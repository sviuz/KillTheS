using DG.Tweening;
using Managers;
using SO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Other.Constants.Constants;

namespace InventoryBased {
  public class InventoryItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {
    public static InventoryItem DragItem;
    
    private InventoryType _inventoryType;
    private ItemType _itemType;
    private Vector3 _itemStartPosition;
    private Sprite _image;//TODO Set Image On Awake
    private RectTransform _rectTransform;
    private Transform _itemParent;
    private CanvasGroup _canvasGroup;
    private RectTransform _dragLayer;
    private bool _canDrag = true;
    public InventoryType GetItemType() => _inventoryType;

    public ItemType GetType() => _itemType;

    public void ChangeInventoryType(InventoryType type) {
      if (Equals(type, _inventoryType)) return;
      
      _inventoryType = type;
    }

    private void Awake() {
      _rectTransform = GetComponent<RectTransform>();
      _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start() {
      _dragLayer = LayerManager.instance.GetRectByTag(TagsEnum.Drag);
    }
    
    public void OnBeginDrag(PointerEventData eventData) {
      DragItem = this;
      _itemStartPosition = transform.localPosition;
      _itemParent = transform.parent;
      transform.SetParent(_dragLayer);
      _canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData) {
      var sq = DOTween.Sequence();
      DragItem = null;
      _canvasGroup.blocksRaycasts = true;
      if (transform.parent == _dragLayer) {
        transform.SetParent(_itemParent);
        sq.Append(transform.DOLocalMove(Vector3.zero, .2f))
          .OnStart(() => { _canDrag = false; })
          .OnComplete(() => {
                        _canDrag = true;
                        transform.localPosition = _itemStartPosition;
                      });
      }
    }

    public void OnDrag(PointerEventData eventData) {
      if (!_canDrag) return;

      _rectTransform.anchoredPosition += eventData.delta;
    }
  }
}