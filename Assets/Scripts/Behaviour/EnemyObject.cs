using System;
using Behaviour.Based;
using Core;
using UnityEngine;

namespace Behaviour {
  public class EnemyObject : EnemyParameters, IEnemyBehavior {
    [SerializeField]
    private CircleCollider2D _circleCollider;
    [SerializeField]
    private SpriteRenderer _exclamationPointSprite;

    [Header("Patrol")]
    [SerializeField]
    private Transform _patrolCenter;
    [SerializeField]
    private float _patrolRadius = 3f;

    public void ShowWarning() {
      _exclamationPointSprite.gameObject.SetActive(true);
    }

    public void HideWarning() {
      _exclamationPointSprite.gameObject.SetActive(false);
    }

    #region Interface relization
    public void Move(float values) {
      throw new NotImplementedException();
    }

    public void Attack() {
      throw new NotImplementedException();
    }

    public void Idle() { }

    public void Hurt() {
      throw new NotImplementedException();
    }

    public void Death() {
      throw new NotImplementedException();
    }

    public void Jump() {
      throw new NotImplementedException();
    }

    public void Patrol() { }

    public void Angry() { }
    public void ReturnToPatrol() { }
    #endregion
  }
}