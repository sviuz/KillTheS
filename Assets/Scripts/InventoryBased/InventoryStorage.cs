using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Other;
using UnityEngine;

namespace InventoryBased {
  public class InventoryStorage : MonoBehaviour {
    public static InventoryStorage instance;
    private List<InventoryItem> _container;

    private void Awake() {
      if (instance == null) {
        instance = this;
      } else {
        Destroy(gameObject);
      }
    }

    private void Start() {
      var str = PlayerPrefs.GetString(Constants.MyInventory);
      if (string.IsNullOrEmpty(str)) {
        Debug.Log("Player prefs is empty");
        return;
      }

      _container = JsonConvert.DeserializeObject<List<InventoryItem>>(str);
    }

    public List<InventoryItem> GetMyContainer() => _container;
  }
}