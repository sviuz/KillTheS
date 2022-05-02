using System;
using System.Collections.Generic;
using System.ComponentModel;
using Core;
using DG.Tweening;
using InventoryBased;
using Other;
using Other.Constants;
using UnityEngine;

namespace Behaviour.Objects {
  public class Chest : MonoBehaviour {
    [SerializeField]
    private GameObject _enterDetector;

    private Container _container;
    private const float OffSetY = 1.5f;
    private float _startDetectorPosY;
    private bool open;
    
    private void Awake() {
      _startDetectorPosY = _enterDetector.transform.localPosition.y;
    }

    private void Update() {
      if (Input.GetKeyUp(KeyCode.E) && open) {
        OpenChest();
      }
    }

    private static void OpenChest() {
      Inventory.OnChangeVisibility?.Invoke();
      OtherInventory.OnChangeVisibility?.Invoke();
      
      List<InventoryItem> chestContainer = InventoryGenerator.Instance.GenerateContainer();

      print(chestContainer.Count.ToString());
      
      OtherInventory.OnSetContainerList?.Invoke(chestContainer);
    }

    private void OnTriggerEnter2D(Collider2D col) {
      if (!col.CompareTag(Constants.Tags.Player)) return;

      open = true;
      EnterDetection();
    }

    private void OnTriggerExit2D(Collider2D col) {
      if (!col.CompareTag(Constants.Tags.Player)) return;
    
      open = false;
      print("close chest ");
      EnterDetection(false);
    }

    private void EnterDetection(bool b = true) {
      float endValue = b ? _startDetectorPosY + OffSetY : _startDetectorPosY;
    
      _enterDetector.transform.DOLocalMoveY(endValue, .2f);
    }
  }
}