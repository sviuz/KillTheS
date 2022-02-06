using System;
using UnityEngine;

namespace InventoryBased {
  [Serializable]
  public abstract class Inventory : MonoBehaviour {
    [SerializeField]
    public CanvasGroup _canvasGroup;

    public InventoryContainer Container;
    

    private void Awake() {
      if (_canvasGroup == null) {
        _canvasGroup = GetComponent<CanvasGroup>();
      }
    }

    protected void SetContainer(InventoryContainer container) {
      if (Container == null) return;
      
      Container = container;
    }
  }
}