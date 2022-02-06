using Newtonsoft.Json;
using Other;
using UnityEngine;

namespace InventoryBased {
  public class InventoryManager : MonoBehaviour {
    private InventoryContainer _myInventoryContainer;
    private InventoryContainer _quickInventoryContainer;

    private void Awake() {
      LoadInventories();
    }

    private void Start() {
      SetInventories();
    }

    private void LoadInventories() {
      _myInventoryContainer = JsonConvert.DeserializeObject<InventoryContainer>(
        PlayerPrefs.GetString(Constants.InventoryType.MyInventory.ToString()));
      _quickInventoryContainer = JsonConvert.DeserializeObject<InventoryContainer>(
        PlayerPrefs.GetString(Constants.InventoryType.QuickInventory.ToString()));
    }

    private void SetInventories() {
      MyInventory.OnSetContainer?.Invoke(_myInventoryContainer);
      QuickInventory.OnSetContainer?.Invoke(_quickInventoryContainer);
    }
  }
}