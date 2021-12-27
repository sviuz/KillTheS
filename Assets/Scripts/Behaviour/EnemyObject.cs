using System;
using Behaviour.Based;
using DG.Tweening;
using Other;
using UnityEngine;

namespace Behaviour {
  public class EnemyObject : EnemyParameters, IEnemyBehavior {
    [SerializeField]
    private BoxCollider2D _boxCollider2D;
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private CircleCollider2D _circleCollider;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Sprite _deathSprite;
    private Vector2 _patrolLeft;
    private Vector2 _patrolRight;
    private float _patrolRadius = 3f;
    private Sequence patrollingCoroutine;
    private bool isAlive = true;

    public bool IsAlive => isAlive;
    
    private void Awake() {
      var tr = transform.position;
      _patrolLeft = new Vector2(tr.x - _patrolRadius * 2, tr.y);
      _patrolRight = new Vector2(tr.x, tr.y);
      SpeedPoints = 2f;
      HealthPoints = 30;
      isPatrolling = true;

      CheckForNull();
    }

    private void OnTriggerEnter2D(Collider2D col) {
      if (col.CompareTag(Data.Tags.Player)) {
        print("OnTriggerEnter2D");
        if (isAlive) {
          StopPatrolling();
          _animator.Play("Idle");
          Angry();
        }
      }
    }

    private void OnTriggerExit2D(Collider2D other) {
      if (other.CompareTag(Data.Tags.Player)) {
        print("OnTriggerExit2D");
        if (isAlive) {
          Patrol();
        }
      }
    }

    private void CheckForNull() {
      if (!_animator) {
        _animator = GetComponent<Animator>();
      }

      if (!_spriteRenderer) {
        _spriteRenderer = GetComponent<SpriteRenderer>();
      }

      if (!_boxCollider2D) {
        _boxCollider2D = GetComponent<BoxCollider2D>();
      }

      if (!_rigidbody2D) {
        _rigidbody2D = GetComponent<Rigidbody2D>();
      }
    }

    public void GetDamage(int value) {
      
      print("GetDamage");
      if (HealthPoints > value) {
        _animator.SetTrigger("Damage");
        HealthPoints -= value;
      } else if (HealthPoints <= 0){
        print("test1");
        Death();
      } else {
        print("test2");
        _animator.SetTrigger("Damage");
        Invoke(nameof(Death), .3f);
      }
    }

    private void Start() {
      Patrol();
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
      isAlive = false;
      StopPatrolling();
      _animator.Play("Death");
      _boxCollider2D.enabled = false;
      _rigidbody2D.bodyType = RigidbodyType2D.Static;
      _spriteRenderer.sprite = _deathSprite; 
      patrollingCoroutine.Kill();
      enabled = false;
      
      // Destroy(gameObject);
    }

    public void Jump() {
      throw new NotImplementedException();
    }

    public void StopPatrolling() {
      patrollingCoroutine.Kill();
    }

    public void Patrol() {
      var tr = transform.position;
      _patrolLeft = new Vector2(tr.x - _patrolRadius * 2, tr.y);
      _patrolRight = new Vector2(tr.x, tr.y);
      _spriteRenderer.flipX = true;
      patrollingCoroutine = DOTween.Sequence();
      patrollingCoroutine.AppendInterval(3f).Append(transform.DOMoveX(_patrolLeft.x, 3f).SetEase(Ease.Linear).OnStart(
        () => { _animator.Play("SkeletonRun"); }).OnComplete(() => {
                                                               _animator.Play("Idle");
                                                               _spriteRenderer.flipX = !_spriteRenderer.flipX;
                                                             }));
      patrollingCoroutine.AppendInterval(3f).Append(transform.DOMoveX(_patrolRight.x, 3f).SetEase(Ease.Linear).OnStart(
        () => { _animator.Play("SkeletonRun"); }).OnComplete(() => {
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