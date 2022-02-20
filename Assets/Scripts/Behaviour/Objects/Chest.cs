using System.Collections.Generic;
using System.ComponentModel;
using Core;
using DG.Tweening;
using InventoryBased;
using Other;
using UnityEngine;

namespace Behaviour.Objects {
  public class Chest : MonoBehaviour {
    [SerializeField]
    private GameObject _enterDetector;

    private Container _container;
    private const float OffSetY = 1.5f;
    private float _startDetectorPosY;

    private void Awake() {
      _startDetectorPosY = _enterDetector.transform.localPosition.y;
    }

    private static void OpenChest() {
      Inventory.OnChangeVisibility?.Invoke();

      List<InventoryItem> chestContainer = InventoryGenerator.Instance.GenerateContainer();

      Inventory.OnSetContainerList?.Invoke(chestContainer);
    }

    private void OnTriggerEnter2D(Collider2D col) {
      if (!col.CompareTag(Constants.Tags.Player)) return;
        
      EnterDetection();
    }

    private void OnTriggerExit2D(Collider2D col) {
      if (!col.CompareTag(Constants.Tags.Player)) return;
    
      print("close chest ");
      EnterDetection(false);
    }

    private void EnterDetection(bool b = true) {
      float endValue = b ? _startDetectorPosY + OffSetY : _startDetectorPosY;
    
      _enterDetector.transform.DOLocalMoveY(endValue, .2f);
    }
  }
}