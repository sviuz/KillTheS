using System;
using UnityEngine;

namespace InventoryBased {
  [Serializable]
  public  class Inventory : MonoBehaviour {
    public static Inventory instance;
    [SerializeField]
    public CanvasGroup _canvasGroup;

    public InventoryContainer Container;
    

    private void Awake() {
      if (instance == null) {
        instance = this;
      } else {
        Destroy(gameObject);
      }
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