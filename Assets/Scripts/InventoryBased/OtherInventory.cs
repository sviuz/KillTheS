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

    private void Awake() {
      OnSetContainerList += OnSetContainerList;
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
      SetContainerList(InventoryStorage.instance.GetMyContainer());
    }
    
    private void SetContainerList(List<InventoryItem> list) {
      if (list == null) return;
      
      _container.InventoryItems = list;

      if (_container.InventorySlots.Count==0) {
        throw new NullReferenceException("InventorySlots are empty");
        return;
      }
      
      for (int index = 0; index < _container.InventoryItems.Count; index++) {
        var item = _container.InventoryItems[index];
        var obj = Instantiate(item, Vector3.zero, Quaternion.identity);
        _container.InventorySlots[index].SetObject(obj, false);
      }
    }
  }
}