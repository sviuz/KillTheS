using Other;
using UnityEngine;

namespace Behaviour.Objects {
  public class PickableObject : MonoBehaviour {
    [SerializeField]
    private string Name;
    [SerializeField]
    private Data.ItemType _itemType;

    public string itemType {
      get {
        return _itemType.ToString();
      }
    }
  }
}