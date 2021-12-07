using System;
using Other;
using UnityEngine;

namespace Behaviour.Based {
  public class InternalCollider : MonoBehaviour {
    [SerializeField]
    private EnemyObject _enemy;

    private void Start() {
      if (!_enemy) {
        _enemy = transform.parent.GetComponent<EnemyObject>();
      }
    }

    private void OnTriggerEnter2D(Collider2D other) {
      if (other.transform.CompareTag(Data.Tags.Player)) {
        print("OnTriggerEnter2D");
        _enemy.ShowWarning();
      }
    }

    private void OnTriggerExit2D(Collider2D other) {
      if (other.transform.CompareTag(Data.Tags.Player)) {
        print("OnTriggerExit2D");
        _enemy.HideWarning();
      }
    }
  }
}