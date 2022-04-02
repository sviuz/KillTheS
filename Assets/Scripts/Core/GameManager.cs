using System;
using InventoryBased;
using UnityEngine;
using Zenject;

namespace Core {
  public class GameManager : MonoBehaviour {
    [SerializeField]
    private GameObject _player;

    private bool inventoryOpen;
    
    [Inject]
    public Vector2 GetPlayerPosition() {
      if (_player) {
        return _player.transform.position;
      }
      throw new NullReferenceException("Player is not set");
    }

    private void Update() {
      if (Input.GetKeyUp(KeyCode.I)) {
        Inventory.OnChangeVisibility?.Invoke();
      }
      
    }
  }
}