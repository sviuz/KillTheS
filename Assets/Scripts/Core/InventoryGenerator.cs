using System;
using System.Collections.Generic;
using InventoryBased;
using SO;
using UnityEngine;
using static Other.Constants;
using Random = UnityEngine.Random;

namespace Core {
  public class InventoryGenerator : MonoBehaviour {
    public static InventoryGenerator Instance;
    [SerializeField] private InventoryItemsSO _so;

    private void Awake() {
      if (Instance == null) {
        Instance = this;
      } else {
        Destroy(gameObject);
      }
    }

    public List<InventoryItem> GenerateContainer() {
      int listCount = Random.Range(2, 5);
      var list = new List<InventoryItem>();
      for (var i = 0; i < listCount; i++) {
        InventoryItem item = GenerateRandomItem();
        list.Add(item);
      }
      return list;
    }

    private ItemType GetRandomItemType() {
      Array values = Enum.GetValues(typeof(ItemType));
      return (ItemType)values.GetValue(Random.Range(0, values.Length - 1));
    }
    
    private InventoryItem GenerateRandomItem() {
      List<InventoryItem> list = _so.list;
      InventoryItem item = list[Random.Range(0, list.Count - 1)];

      return item;
    }
  }
}