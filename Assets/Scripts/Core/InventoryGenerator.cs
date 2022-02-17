using System;
using System.Collections.Generic;
using InventoryBased;
using SO;
using UnityEngine;
using static Other.Constants;
using Random = UnityEngine.Random;

namespace Core {
  public class InventoryGenerator : MonoBehaviour {
    public static InventoryGenerator instance;
    [SerializeField]
    private InventoryItemsSO _so;

    public InventoryItem GenerateRandomItem() {
      List<InventoryItem> list = _so.list;
      
      return list[Random.Range(0, list.Count + 1)];
    }

    private InventoryItem GenerateRandomItem(ItemType type) {
      List<InventoryItem> list = _so.list.FindAll(x => x.GetType() == type);

      return list[Random.Range(0, list.Count + 1)];
    }

    public List<InventoryItem> GenerateContainer() {
      int listCount = Random.Range(2, 5);
      var list = new List<InventoryItem>();
      for (var i = 0; i < listCount; i++) {
        ItemType type = GetRandomItemType();
        InventoryItem item = GenerateRandomItem(type);
        list.Add(item);
      }
      return list;
    }

    private ItemType GetRandomItemType() {
      Array values = Enum.GetValues(typeof(ItemType));
      return (ItemType)values.GetValue(Random.Range(0, values.Length - 1));
    }
  }
}