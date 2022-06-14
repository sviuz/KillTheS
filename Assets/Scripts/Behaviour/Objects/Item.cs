using Behaviour.Based.Interfaces;
using UnityEngine;

namespace Behaviour.Objects {
  public class Item : MonoBehaviour, IPickable {
    [SerializeField] private ParticleSystem _particleSystem;

    public virtual void Pick(Vector3 position) {
      Debug.Log("Add health");
    }

    public void Drop(Vector3 position) {
      transform.position = position;
    }

    protected virtual void Destroy() {
      Destroy(gameObject);
    }
  }
}