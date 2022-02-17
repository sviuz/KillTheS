using System;
using System.Collections.Generic;
using UnityEngine;
using static Other.Constants;

namespace InventoryBased {
  [Serializable]
  public class Inventory : MonoBehaviour {
    public static Action<InventoryItem> OnAddToFullInventoryItemsCount;
    public static Action<InventoryItem> OnAddToQuickInventoryItemsCount;
    public static RemoveItemFromQuickListEvent OnRemoveItemFromQuickList;
    public static Action OnChangeVisibility;
    public static Action<List<InventoryItem>> OnSetContainerList;
    
    [SerializeField]
    private CanvasGroup _canvasGroup;
    [SerializeField]
    private GameObject _inventoryObject;
    [SerializeField]
    private bool _visible = false;
    private InventoryContainer Container;
    
    private void Awake() {
      if (_canvasGroup == null) {
        _canvasGroup = GetComponent<CanvasGroup>();
      }

      OnChangeVisibility += ChangeInventoryVisibility;
      OnSetContainerList += SetContainerList;
    }
    
    private void OnDestroy() {
      OnChangeVisibility -= ChangeInventoryVisibility;
    }

    private void Update() {
      if (Input.GetKeyUp(KeyCode.Alpha1)) {
        if (InventoryTransfer.RemoveItemFromQuickInv(0)) return;

        print("No available item at this place");
      } else if (Input.GetKeyUp(KeyCode.Alpha2)) {
        if (InventoryTransfer.RemoveItemFromQuickInv(1)) return;

        print("No available item at this place");
      } else if (Input.GetKeyUp(KeyCode.Alpha3)) {
        if (InventoryTransfer.RemoveItemFromQuickInv(2)) return;

        print("No available item at this place");
      } else if (Input.GetKeyUp(KeyCode.Alpha4)) {
        if (InventoryTransfer.RemoveItemFromQuickInv(3)) return;

        print("No available item at this place");
      } else if (Input.GetKeyUp(KeyCode.Alpha5)) {
        if (InventoryTransfer.RemoveItemFromQuickInv(4)) return;

        print("No available item at this place");
      }
    }

    public void ChangeInventoryVisibility() {
      _visible = !_visible;
      _canvasGroup.blocksRaycasts = _visible;
      _inventoryObject.SetActive(_visible);
      if (_visible) {
        SetContainerList(InventoryStorage.instance.GetMyContainer());
      } else {
        SetContainerList(null);
      }
    }

    protected void SetContainerList(List<InventoryItem> list) {
      if (Container == null) return;
      
      Container._fullInventoryItems = list;
    }

    private void ClearContainer() {
      Container = null;
    }
  }
}