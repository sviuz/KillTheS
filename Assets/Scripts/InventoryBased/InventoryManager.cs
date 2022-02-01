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
      var myContainer = JsonConvert.DeserializeObject<InventoryItem>(
        PlayerPrefs.GetString(Data.InventoryType.MyInventory.ToString()));
      var quickContainer = JsonConvert.DeserializeObject<InventoryItem>(
        PlayerPrefs.GetString(Data.InventoryType.QuickInventory.ToString()));
    }

    private void SetInventories() {
      
    }
  }
}