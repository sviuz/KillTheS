using System.Collections.Generic;
using Core;
using SRF;
using UnityEngine;

namespace Behaviour.Objects.Items {
  public class ItemContainer : Singleton<ItemContainer> {
    [SerializeField] private List<GameObject> items;

    public GameObject GetRandomItem() => items.Random();
  }
}