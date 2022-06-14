using InventoryBased;
using UnityEngine;

namespace Core {
  public class InputController : MonoBehaviour {
    private void Update() {
      if (Input.GetKeyUp(KeyCode.I)) {
        Inventory.OnChangeVisibility?.Invoke();
      }
    }
  }
}