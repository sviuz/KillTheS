﻿using System;
using Behaviour.Based;
using Behaviour.GameActions;
using Ui.Dialogs;
using UnityEngine;
using UnityEngine.UI;
using static Other.Constants;

namespace Behaviour {
  public class PlayerMovement : SubjectParameters,
    IPlayerBehavior {
    public static Action<bool> OnSetMovement;
    [SerializeField]
    private float _jumpForce = 7.5f;
    [SerializeField]
    private Sensor_Bandit _groundSensor;
    [SerializeField]
    private Image test;

    private Action OnDialogueStart;

    private Animator _animator;
    private Rigidbody2D _body2d;
    private BoxCollider2D _boxCollider;
    private bool _grounded;
    private bool _combatIdle;
    private bool _isDead;
    private bool _showDialogue;
    private bool _move = true;

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
    
    private void OnTriggerEnter2D(Collider2D col) {
      if (col.TryGetComponent(out DialogueTrigger dialogueTrigger)) {
        print(nameof(OnTriggerEnter2D));
        OnDialogueStart += dialogueTrigger.OnTrigger;
        dialogueTrigger.OnShowPopUp?.Invoke();
      }
    }

    private void OnTriggerExit2D(Collider2D other) {
      if (other.TryGetComponent(out DialogueTrigger dialogueTrigger)) {
        print(nameof(OnTriggerExit2D));
        OnDialogueStart -= dialogueTrigger.OnTrigger;
        dialogueTrigger.OnHidePopUp?.Invoke();
      }
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
      } else if (Input.GetKeyUp(KeyCode.E)) {
        ExecuteDialogue();
      } else {
        Idle();
      }
    }

    private void SetMovement(bool status) {
      _move = status;
    }

    private void ExecuteDialogue() {
      OnDialogueStart?.Invoke();
    }

    public void Move(float inputX) {
      if (inputX > 0) {
        transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
      } else if (inputX < 0) {
        transform.localScale = Vector3.one;
      }

      _body2d.velocity = new Vector2(inputX * Speed, _body2d.velocity.y);

      _animator.SetFloat(nameof(MoveTriggers.AirSpeed), _body2d.velocity.y);
    }

    public void Move() {
      _animator.SetInteger(nameof(MoveTriggers.AnimState), 2);
    }

    public void Attack() {
      _animator.SetTrigger(nameof(MoveTriggers.Attack));
      Invoke(nameof(Hit), .15f);
    }

    private void Hit() {
      Collider2D enemy = Physics2D.OverlapCircle(AttackPosition.position, AttackRange, Mask);
      if (enemy) {
        try {
          var e = enemy.GetComponent<EnemyObject>();
          if (e.isAlive) {
            e.Hurt(AttackPoints);
          }
        }
        catch (Exception e) {
          Console.WriteLine("Enemy is already dead.");
          throw;
        }
      }
    }

    public void Idle() {
      _animator.SetInteger(MoveTriggers.AnimState.ToString(), 0);
    }

    public void Hurt(int value) {
      _animator.SetTrigger(MoveTriggers.Hurt.ToString());
    }

    public void Death() {
      _animator.SetTrigger(!_isDead
        ? MoveTriggers.Death.ToString()
        : MoveTriggers.Recover.ToString());
      _isDead = !_isDead;
    }

    public void Jump() {
      _animator.SetTrigger(MoveTriggers.Jump.ToString());
      _grounded = false;
      _animator.SetBool(MoveTriggers.Grounded.ToString(), _grounded);
      _body2d.velocity = new Vector2(_body2d.velocity.x, _jumpForce);
      _groundSensor.Disable(0.2f);
    }

    public void CombatIdle() {
      _animator.SetInteger(MoveTriggers.AnimState.ToString(), 1);
    }

    private void ChangeCombatPose() {
      _combatIdle = !_combatIdle;
      _boxCollider.size = _combatIdle ? _defendedBoxColliderX : _defaultBoxColliderX;
    }

    private void Grounded() {
      if (!_grounded && _groundSensor.State()) {
        _grounded = true;
        _animator.SetBool(MoveTriggers.Grounded.ToString(), _grounded);
      }

      if (_grounded && !_groundSensor.State()) {
        _grounded = false;
        _animator.SetBool(MoveTriggers.Grounded.ToString(), _grounded);
      }
    }
  }
}