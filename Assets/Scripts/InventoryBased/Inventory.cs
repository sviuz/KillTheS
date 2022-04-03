using System;
using System.Collections.Generic;
using Behaviour;
using Behaviour.Based;
using Other;
using UnityEngine;

namespace InventoryBased {
  public class Inventory : MonoBehaviour {
    public static Action OnChangeVisibility;
    public static Action<List<InventoryItem>> OnSetContainerList;
    public static Action<InventoryItem> OnMoveItem;

    [SerializeField] private InventoryContainer _container;

    private void Awake() {
      OnChangeVisibility += ShowInventory;
      OnSetContainerList += SetContainerList;
      OnMoveItem += MoveItem;
    }

    private void Start() {
      ShowInventory();
    }

    private void OnDestroy() {
      OnChangeVisibility -= ShowInventory;
      OnSetContainerList -= SetContainerList;
      OnMoveItem -= MoveItem;
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
      if (_container.Visible) {
        PlayerMovement.OnSetMovement?.Invoke(true);
        _container.Visible = false;
        _container.InventoryCanvasGroup.blocksRaycasts = false;
        _container.InventoryObject.SetActive(false);
        return;
      }

      PlayerMovement.OnSetMovement?.Invoke(false);
      _container.Visible = true;
      _container.InventoryCanvasGroup.blocksRaycasts = true;
      _container.InventoryObject.SetActive(true);
    }

    private void SetContainerList(List<InventoryItem> list) {
      if (list == null) return;
      
      _container.FullInventoryItems = list;

      for (int index = 0; index < _container.FullInventoryItems.Count; index++) {
        var item = _container.FullInventoryItems[index];
        var obj = Instantiate(item, Vector3.zero, Quaternion.identity);
        _container.FullInventorySlots[index].SetObject(obj, false);
      }
    }

    private void MoveItem(InventoryItem item) {
      if (item.GetItemType() == Constants.InventoryType.FullInventory) {
        _container.FullInventoryItems.Remove(item);
        _container.QuickInventoryItems.Add(item);
      } else {
        _container.QuickInventoryItems.Remove(item);
        _container.FullInventoryItems.Add(item);
      }
    }
  }
}