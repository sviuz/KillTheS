using System;
using System.Collections;
using Behaviour.Based;
using Cinemachine.Utility;
using DG.Tweening;
using UnityEngine;

namespace Behaviour {
  public class EnemyObject : EnemyParameters, IEnemyBehavior {
    [SerializeField]
    private CircleCollider2D _circleCollider;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private GameObject _exclamationPointSprite;
    [SerializeField]
    private Animator _animator;

    [Header("Patrol")]
    private Vector2 _patrolLeft;
    private Vector2 _patrolRight;
    private float _patrolRadius = 3f;
    private Sequence patrollingCoroutine;
    
    
    private void Awake() {
      var tr = transform.position;
      _patrolLeft = new Vector2(tr.x - _patrolRadius*2, tr.y);
      _patrolRight = new Vector2(tr.x, tr.y);
      SpeedPoints = 2f;
      isPatrolling = true;

      if (!_animator) {
        _animator = GetComponent<Animator>();
      }

      if (!_spriteRenderer) {
        _spriteRenderer = GetComponent<SpriteRenderer>();
      }
    }

    private void Start() {
      Patrol();
    }

    public void ShowWarning() {
      _exclamationPointSprite.SetActive(true);
    }

    public void HideWarning() {
      _exclamationPointSprite.SetActive(false);
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

    public void StopPatrolling() {
      patrollingCoroutine.Kill();
      _animator.Play("Idle");
    }

    public void Patrol() {
      var tr = transform.position;
      _patrolLeft = new Vector2(tr.x - _patrolRadius*2, tr.y);
      _patrolRight = new Vector2(tr.x, tr.y);
      _spriteRenderer.flipX = true;
      patrollingCoroutine = DOTween.Sequence();
      patrollingCoroutine.AppendInterval(3f).Append(transform.DOMoveX(_patrolLeft.x, 3f).SetEase(Ease.Linear).OnStart(
        () => {
          _animator.Play("SkeletonRun");
        }).OnComplete(() => {
                        _animator.Play("Idle");
                        _spriteRenderer.flipX = !_spriteRenderer.flipX;
                      }));
      patrollingCoroutine.AppendInterval(3f).Append(transform.DOMoveX(_patrolRight.x, 3f).SetEase(Ease.Linear).OnStart(
        () => {
          _animator.Play("SkeletonRun");
        }).OnComplete(() => {
                        _animator.Play("Idle");
                        _spriteRenderer.flipX = !_spriteRenderer.flipX;
                      }));
      patrollingCoroutine.SetLoops(-1);
      patrollingCoroutine.Play();
    }
    
    public void Angry() { }
    public void ReturnToPatrol() { }
    #endregion
  }
}