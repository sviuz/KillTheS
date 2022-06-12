using System;
using Behaviour.Based;
using Behaviour.HealthItem;
using Behaviour.Objects;
using JetBrains.Annotations;
using Level;
using Ui.Level;
using UnityEngine;
using static Other.Constants.Constants;

namespace Behaviour {
  public class PlayerMovement : SubjectParameters {
    public static Action<bool> OnSetMovement;
    [SerializeField]
    private float _jumpForce = 7.5f;
    [SerializeField]
    private PlayerState _groundSensor;

    private Animator _animator;
    private Rigidbody2D _body2d;
    private BoxCollider2D _boxCollider;
    private bool _grounded;
    private bool _combatIdle;
    private bool _isDead;
    private bool _move = true;
    private bool _attack;

    private Vector2 _defaultBoxColliderX = new Vector2(0.8f, 1.5f);
    private Vector2 _defendedBoxColliderX = new Vector2(2f, 1.5f);

    private void Awake() {
      _animator = GetComponent<Animator>();
      _body2d = GetComponent<Rigidbody2D>();
      _boxCollider = GetComponent<BoxCollider2D>();

      OnSetMovement += SetMovement;
    }

    private void OnDestroy() {
      OnSetMovement -= SetMovement;
    }

    private void Update() {
      if (!_move) return;
      Grounded();
      float inputX = Input.GetAxis("Horizontal");
      Move(inputX);
      MainBehaviour(inputX);
    }

    private void MainBehaviour(float value) {
      
      if (Input.GetMouseButtonDown(0)) {
        Attack();
      } else if (Input.GetKeyDown(KeyCode.Mouse1)) {
        ChangeCombatPose();
      } else if (Input.GetKeyDown("space") && _grounded) {
        Jump();
      } else if (Mathf.Abs(value) > Mathf.Epsilon) {
        Move();
      } else if (_combatIdle) {
        CombatIdle();
      } else {
        Idle();
      }
    }

    private void SetMovement(bool status) {
      _move = status;
    }

    private void Move(float inputX) {
      if (inputX > 0) {
        transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
      } else if (inputX < 0) {
        transform.localScale = Vector3.one;
      }

      _body2d.velocity = new Vector2(inputX * Speed, _body2d.velocity.y);

      _animator.SetFloat(nameof(MoveTriggers.AirSpeed), _body2d.velocity.y);
    }

    private void Move() {
      _animator.SetInteger(nameof(MoveTriggers.AnimState), 2);
    }

    private void Attack() {
      if (_attack) return;

      _attack = true;
      _animator.SetTrigger(nameof(MoveTriggers.Attack));
    }

    [UsedImplicitly]//used in animations
    public void ReturnState() {
      _attack = false;
    }

    [UsedImplicitly]
    private void Hit() {
      Collider2D[] cols = Physics2D.OverlapCircleAll(AttackPosition.position, AttackRange);
      if (cols.Length == 0) return;

      for (int i = 0; i < cols.Length; i++) {
        if (cols[i].TryGetComponent(out EnemyHealth _health)) {
          _health.TakeDamage(10);
        }
      }

      for (int i = 0; i < cols.Length; i++) {
        if (cols[i].TryGetComponent(out Chest _chest)) {
          _chest.BrokeChest();
        }
      }
    }

    private void Idle() {
      _animator.SetInteger(nameof(MoveTriggers.AnimState), 0);
    }

    public void Hurt() {
      _animator.SetTrigger(nameof(MoveTriggers.Hurt));
    }

    public void Death() {
      _animator.SetTrigger(!_isDead
        ? nameof(MoveTriggers.Death)
        : nameof(MoveTriggers.Recover));
      _isDead = !_isDead;
      LevelUI.Instance.Lose();
    }

    private void Jump() {
      _animator.SetTrigger(nameof(MoveTriggers.Jump));
      _grounded = false;
      _animator.SetBool(nameof(MoveTriggers.Grounded), _grounded);
      _body2d.velocity = new Vector2(_body2d.velocity.x, _jumpForce);
      _groundSensor.Disable(0.2f);
    }

    private void CombatIdle() {
      _animator.SetInteger(nameof(MoveTriggers.AnimState), 1);
    }

    private void ChangeCombatPose() {
      _combatIdle = !_combatIdle;
      _boxCollider.size = _combatIdle ? _defendedBoxColliderX : _defaultBoxColliderX;
    }

    private void Grounded() {
      if (!_grounded && _groundSensor.State()) {
        _grounded = true;
        _animator.SetBool(nameof(MoveTriggers.Grounded), _grounded);
      }

      if (!_grounded || _groundSensor.State()) return;

      _grounded = false;
      _animator.SetBool(nameof(MoveTriggers.Grounded), _grounded);
    }

    private void OnTriggerEnter2D(Collider2D col) {
      if (col.TryGetComponent(out Objects.Items.HealthItem item)) {
        Debug.Log(item.name);
        item.Pick(transform.position);
      }

      if (col.TryGetComponent(out WinObject winObject)) {
        winObject.Win();
      }
    }
  }
}