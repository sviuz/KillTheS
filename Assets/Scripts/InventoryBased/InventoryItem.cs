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
    [SerializeField]
    private Image _image;
    [SerializeField]
    private PickableObject _pickableObject;
    [SerializeField]
    private Vector3 itemStartPosition;

    public static InventoryItem dragItem;
    private RectTransform rectTransform;
    private Transform itemParent;
    private CanvasGroup canvasGroup;
    private RectTransform dragLayer;
    private bool canDrag { get; set; } = true;

    private void Awake() {
      rectTransform = GetComponent<RectTransform>();
      canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start() {
      dragLayer = LayerManager.instance.GetRectByTag(Data.TagsEnum.Drag);
    }

    public void OnBeginDrag(PointerEventData eventData) {
      print("OnBeginDrag");
      dragItem = this;
      itemStartPosition = transform.localPosition;
      itemParent = transform.parent;
      transform.SetParent(dragLayer);
      canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData) {
      dragItem = null;
      canvasGroup.blocksRaycasts = true;
      if (transform.parent == dragLayer) {
        print("returning item...");
        transform.SetParent(itemParent);
        transform.localPosition = itemStartPosition;
      } 
    }

    public void OnDrag(PointerEventData eventData) {
      if (!canDrag) return;

      print("OnDrag");
      rectTransform.anchoredPosition += eventData.delta;
    }
  }
}