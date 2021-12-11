using System;
using Behaviour.Based;
using UnityEngine;

namespace Behaviour {
  public class EnemyObject : EnemyParameters, ISubjectBehaviour {
    [SerializeField]
    private CircleCollider2D _circleCollider;
    [SerializeField]
    private SpriteRenderer _exclamationPointSprite;

    private bool _isPatrolling = false;

    private void Awake() {
      _circleCollider.radius = RadiusSearch > 0 ? RadiusSearch : 3.5f;
    }

    private void Start() {
      _isPatrolling = true;
    }

    private void OnTriggerEnter(Collider other) {
      print("JOPA");
    }

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

    public void Idle() {
      throw new NotImplementedException();
    }

    public void Hurt() {
      throw new NotImplementedException();
    }

    public void Death() {
      throw new NotImplementedException();
    }

    public void Jump() {
      throw new NotImplementedException();
    }

    public void CombatIdle() {
      throw new NotImplementedException();
    }

    public void Grounded() {
      throw new NotImplementedException();
    }
    #endregion
  }
}