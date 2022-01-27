using System;
using System.Collections;
using System.Threading.Tasks;
using Behaviour.Based;
using DG.Tweening;
using Other;
using UnityEngine;
using UnityEngine.UI;

namespace Behaviour {
  public class EnemyObject : EnemyParameters, IEnemyBehavior {
    [SerializeField]
    private BoxCollider2D _boxCollider2D;
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Sprite _deathSprite;
    [SerializeField]
    private Slider _hpSlider;
    
    private Vector2 _patrolLeft;
    private Vector2 _patrolRight;
    private float _patrolRadius = 3f;
    private Sequence patrollingCoroutine;
    private Coroutine _attackCoroutine;
    
    private void Awake() {
      CheckForNull();
    }
    
    private void Start() {
      Move();
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

    private void OnTriggerEnter2D(Collider2D col) {
      /*if (!col.CompareTag(Data.Tags.Player)) return;
      if (!isAlive) return;

      StopPatrolling();
      _animator.Play("Idle");
      Angry();*/
    }

    private void OnTriggerExit2D(Collider2D other) {
      /*if (!other.CompareTag(Data.Tags.Player)) return;
      if (!isAlive) return;
      
      Move();*/
    }

    private void OnCollisionEnter2D(Collision2D col) {
      if (col.transform.name != Data.Tags.Player) return;
      if (!isAlive) return;
      
      Attack();
    }

    private void OnCollisionExit2D(Collision2D other) {
      if (_attackCoroutine!=null) {
        StopCoroutine(_attackCoroutine);
      }

      isPatrolling = true;
      Move();
    }

    #region Interface relization
    public void Move(float values = 0) {
      if (isPatrolling) {
        Patrol();
      }
    }

    public void Attack() {
      Collider2D enemy = Physics2D.OverlapCircle(AttackPosition.position, AttackRange, Mask);
      if (!enemy) return;

      _attackCoroutine = StartCoroutine(AttackCoroutine(enemy));
    }

    private IEnumerator AttackCoroutine(Collider2D collider) {
      isPatrolling = false;
      while (true) {
        try {
          var e = collider.GetComponent<Player>();
          if (!e.isAlive) yield break;
          
          e.Hurt(AttackPoints);
          _animator.Play("Attack");
        }
        catch (Exception e) {
          throw new Exception("Player is already dead.");
        }

        yield return new WaitForSeconds(1f);
      }
    }
    
    public void Idle() { }

    public void Hurt(int value) {
      print("HURT");
      Health -= value;
      _animator.SetTrigger("Damage");
      DOSetHp();
      
      if (Health < value) {
        _animator.SetTrigger("Damage");
        Health = 0;
        DOSetHp();
        Invoke(nameof(Death), .3f); 
      }
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
    }

    private void DOSetHp() {
      _hpSlider.value = Health;
    }

    public void Jump() { }

    public void StopPatrolling() {
      patrollingCoroutine.Kill();
    }

    public void Patrol() {
      if (!isPatrolling) return;
      
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
    #endregion
  }
}