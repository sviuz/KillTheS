using Behaviour.Objects.Items;
using UnityEngine;

namespace Behaviour.Objects {
  public class Chest : MonoBehaviour {
    private const float deltaPosX = 0.3f;
    public void BrokeChest() {
      InstantiateItems();
    }

    private void InstantiateItems() {
      const int count = 3;

      for (int i = 0; i < count; i++) {
        var position = transform.position;
        var obj = 
          Instantiate(ItemContainer.Instance.GetRandomItem(), position, Quaternion.identity);
        obj.GetComponent<Item>().Drop(new Vector3(
          GetRandomPointByAxis(position.x), 
          GetRandomPointByAxis(position.y), 
          0));
        Destroy(gameObject);
      }
    }

    private static float GetRandomPointByAxis(float value) => Random.Range(value + deltaPosX, value - deltaPosX);
  }
}