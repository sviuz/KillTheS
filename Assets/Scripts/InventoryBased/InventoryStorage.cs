using System;
using System.Collections.Generic;
using Behaviour.Based;
using Newtonsoft.Json;
using Other;
using UnityEngine;

namespace InventoryBased {
  public class InventoryStorage : MonoBehaviour {
    public static InventoryStorage instance;
    private List<InventoryItem> _fullContainer;
    private List<InventoryItem> _quickContainer;

    private void Awake() {
      if (instance == null) {
        instance = this;
      } else {
        Destroy(gameObject);
      }
    }

  }
}