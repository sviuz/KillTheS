using System;
using System.Collections.Generic;
using Behaviour;
using Behaviour.Based;
using UnityEngine;

namespace InventoryBased {
  public class OtherInventory : MonoBehaviour {
    public static Action<List<InventoryItem>> OnSetContainerList;
    public static Action OnChangeVisibility;
    [SerializeField] private InventoryContainer _container;

    private bool isOpen;
    private void Awake() {
      OnSetContainerList += SetContainerList;
      OnChangeVisibility += ShowInventory;
    }

    private void Start() {
      ShowInventory();
    }

    private void OnDestroy() {
      OnSetContainerList -= SetContainerList;
      OnChangeVisibility -= ShowInventory;
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
      if (isOpen) return;
      if (list == null) return;
      
      _container.FullInventoryItems = list;

      if (_container.FullInventorySlots.Count==0) {
        throw new NullReferenceException("InventorySlots are empty");
      }
      
      for (int index = 0; index < _container.FullInventoryItems.Count; index++) {
        var item = _container.FullInventoryItems[index];
        var obj = Instantiate(item, Vector3.zero, Quaternion.identity);
        _container.FullInventorySlots[index].SetObject(obj, false);
      }

      isOpen = false;
    }
  }
}