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
    private float _patrolSpeed;
    [SerializeField]
    private float _patrolPosition;
    [SerializeField]
    private Transform _patrolPoint;
    [SerializeField]
    private bool isMovingRight;
    private float stopDistance;
    
    private GameManager _gameManager;

    private void Update() {
      Patrol();

      if (Vector2.Distance(transform.position, _gameManager.GetPlayerPosition())<stopDistance) {
        Attack();
      }
      if (Vector2.Distance(transform.position, _gameManager.GetPlayerPosition())>stopDistance) {
        ReturnToPatrol();
      }
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
      if (transform.position.x > _patrolPoint.position.x + _patrolPosition) {
        isMovingRight = false;
      } else if (transform.position.x < _patrolPoint.position.x + _patrolPosition) {
        isMovingRight = true;
      }

      var tr = (Vector2) transform.position;
      transform.position = isMovingRight
        ? new Vector2(tr.x + _patrolSpeed * Time.deltaTime, tr.y)
        : new Vector2(tr.x - _patrolSpeed * Time.deltaTime, tr.y);
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

    public void Grounded() {
      throw new NotImplementedException();
    }

    public void Patrol() {
      if (Vector2.Distance(transform.position, _patrolPoint.position) < _patrolPosition) {
        Idle();
      }
    }

    public void Angry() {
      transform.position = Vector2.MoveTowards(transform.position, _gameManager.GetPlayerPosition(), SpeedPoints * Time.deltaTime);
    }
    public void ReturnToPatrol() {
      transform.position = Vector2.MoveTowards(transform.position, _patrolPoint.position, SpeedPoints * Time.deltaTime);
    }
    #endregion
  }
}