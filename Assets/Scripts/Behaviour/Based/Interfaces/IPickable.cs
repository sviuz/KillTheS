using UnityEngine;

namespace Behaviour.Based.Interfaces {
  public interface IPickable {
    public void Pick(Vector3 position);
    public void Drop(Vector3 position);
  }
}