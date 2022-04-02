using System;
using System.Collections.Generic;
using InventoryBased;
using UnityEngine;

namespace Behaviour.Based {
  public class InventoryContainer : MonoBehaviour {
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private GameObject _inventoryObject;
    [SerializeField] private bool _visible = true;
    [SerializeField] private List<InventorySlot> _fullInventoryContainers;
    [SerializeField] private List<InventoryItem> _inventoryItems;

    private void Awake() {
      _visible = InventoryObject.activeSelf;
    }

    public CanvasGroup InventoryCanvasGroup {
      get {
        return _canvasGroup;
      }
      set {
        _canvasGroup = value;
      }
    }

    public GameObject InventoryObject {
      get {
        return _inventoryObject;
      }
      set {
        _inventoryObject = value;
      }
    }

    public bool Visible {
      get {
        return _visible;
      }
      set {
        _visible = value;
      }
    }

    public List<InventorySlot> InventorySlots {
      get {
        return _fullInventoryContainers;
      }
      set {
        _fullInventoryContainers = value;
      }
    }

    public List<InventoryItem> InventoryItems {
      get {
        return _inventoryItems;
      }
      set {
        _inventoryItems = value;
      }
    }
  }
}