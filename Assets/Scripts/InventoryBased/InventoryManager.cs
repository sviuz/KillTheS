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

    private void LoadInventories() {
      _myInventoryContainer = JsonConvert.DeserializeObject<InventoryContainer>(
        PlayerPrefs.GetString(Constants.InventoryType.FullInventory.ToString()));
      _quickInventoryContainer = JsonConvert.DeserializeObject<InventoryContainer>(
        PlayerPrefs.GetString(Constants.InventoryType.QuickInventory.ToString()));
    }
  }
}