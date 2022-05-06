using Behaviour.Objects.Items;
using UnityEngine;

namespace Behaviour.Objects {
  public class Chest : MonoBehaviour {
    public void BrokeChest() {
      InstantiateItems();
    }

    private void InstantiateItems() {
      int count = 3;

      for (int i = 0; i < count; i++) {
        var obj = Instantiate(ItemContainer.Instance.GetRandomItem(), transform.position, Quaternion.identity);
        obj.GetComponent<Item>().Drop();
      }
    }
  }
  
}