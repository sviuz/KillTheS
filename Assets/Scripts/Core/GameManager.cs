using System;
using InventoryBased;
using UnityEngine;

namespace Core {
  public class GameManager : MonoBehaviour {
    [SerializeField]
    private GameObject _player;

    private bool inventoryOpen;
    

    private void Update() {
      if (Input.GetKeyUp(KeyCode.I)) {
        Inventory.OnChangeVisibility?.Invoke();
      }
      
    }
  }
}