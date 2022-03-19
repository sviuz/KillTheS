using System;
using System.Collections.Generic;
using Behaviour;
using UnityEngine;
using static Other.Constants;

namespace InventoryBased {
  public class Inventory : MonoBehaviour {
    public static Action OnChangeVisibility;
    public static Action<List<InventoryItem>> OnSetContainerList;

    [SerializeField]private CanvasGroup _canvasGroup;
    [SerializeField]private GameObject _inventoryObject;
    [SerializeField]private bool _visible = true;
    private InventoryContainer Container;

    private void Awake() {
      if (_canvasGroup == null) {
        _canvasGroup = GetComponent<CanvasGroup>();
      }

      _visible = _inventoryObject.activeSelf;
      OnChangeVisibility += ShowInventory;
      OnSetContainerList += SetContainerList;
    }

    private void Start() {
      ShowInventory();
    }

    private void OnDestroy() {
      OnChangeVisibility -= ShowInventory;
    }

    private void Update() {
      if (Input.GetKeyUp(KeyCode.Alpha1)) {
        print("No available item at this place");
      } else if (Input.GetKeyUp(KeyCode.Alpha2)) {
        print("No available item at this place");
      } else if (Input.GetKeyUp(KeyCode.Alpha3)) {
        print("No available item at this place");
      } else if (Input.GetKeyUp(KeyCode.Alpha4)) {
        print("No available item at this place");
      } else if (Input.GetKeyUp(KeyCode.Alpha5)) {
        print("No available item at this place");
      }
    }

    private void ShowInventory() {
      if (_visible) {
        PlayerMovement.OnSetMovement?.Invoke(true);
        _visible = false;
        _canvasGroup.blocksRaycasts = false;
        _inventoryObject.SetActive(false);
        return;
      }

      PlayerMovement.OnSetMovement?.Invoke(false);
      _visible = true;
      _canvasGroup.blocksRaycasts = true;
      _inventoryObject.SetActive(true);
      SetContainerList(InventoryStorage.instance.GetMyContainer());
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