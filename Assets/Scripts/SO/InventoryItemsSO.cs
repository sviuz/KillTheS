using System.Collections.Generic;
using InventoryBased;
using UnityEngine;

namespace SO {
  [CreateAssetMenu(fileName = "InventoryItems", menuName = "InventoryItems", order = 0)]
  public class InventoryItemsSO : ScriptableObject {
    public List<InventoryItem> list;
  }
}