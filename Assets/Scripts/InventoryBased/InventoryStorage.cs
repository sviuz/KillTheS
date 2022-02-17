using System.Collections.Generic;
using UnityEngine;

namespace InventoryBased {
  public class InventoryStorage : MonoBehaviour {
    public static InventoryStorage instance;
    private List<InventoryItem> _container;
  
    private void Start() {
      _container = InventoryTransfer.GetContainer()._fullInventoryItems;
    }

    public List<InventoryItem> GetMyContainer() => _container;
  }
}