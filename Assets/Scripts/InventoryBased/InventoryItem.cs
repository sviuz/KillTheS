using System;
using Behaviour.Objects;
using DG.Tweening;
using Managers;
using Other;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventoryBased {
  public class InventoryItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {
    public static InventoryItem dragItem;

    [SerializeField]
    private Image _image;
    [SerializeField]
    private PickableObject _pickableObject;
    [SerializeField]
    private Vector3 itemStartPosition;
    
    private RectTransform rectTransform;
    private Transform itemParent;
    private CanvasGroup canvasGroup;
    private RectTransform dragLayer;
    private bool canDrag { get; set; } = true;
    public Data.InventoryType inventoryType { get; private set; }
    
    public void ChangeInventoryType(Data.InventoryType type) {
      inventoryType = type;
    }
    
    private void Awake() {
      rectTransform = GetComponent<RectTransform>();
      canvasGroup = GetComponent<CanvasGroup>();
      inventoryType = Data.InventoryType.MyInventory;
    }
    
    private void Start() {
      dragLayer = LayerManager.instance.GetRectByTag(Data.TagsEnum.Drag);
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