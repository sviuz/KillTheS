using Behaviour.Based;
using UnityEngine;
using static Other.Data.PLayerData;

namespace Behaviour {
  public class Player : MonoBehaviour,
    IPlayerBehavior {
    [SerializeField]
    private float _speed = 4.0f;
    [SerializeField]
    private float _jumpForce = 7.5f;
    [SerializeField]
    private Sensor_Bandit _groundSensor;
    [SerializeField]
    private Transform _attackPoint;
    [SerializeField]
    private float _attackRange = .5f;
    [SerializeField]
    private LayerMask _enemyLayerMask;

    //1 - right, -1 - left
    private int raycastDirection = 1;
    
    private Animator _animator;
    private Rigidbody2D _body2d;
    private bool _grounded;
    private bool _combatIdle;
    private bool _isDead;

    private void Start() {
      _animator = GetComponent<Animator>();
      _body2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
      Grounded();
      float inputX = Input.GetAxis("Horizontal");
      Move(inputX);
      MainBehaviour(inputX);
      
      
      
      Vector3 forward = transform. TransformDirection(Vector3. forward) * 30;
      Debug. DrawRay(transform.position, _attackPoint.position, Color.green);

    }

    private void MainBehaviour(float value) {
      if (Input.GetKeyDown("e")) {
        Death();
      } else if (Input.GetKeyDown("q")) {
        Hurt();
      } else if (Input.GetMouseButtonDown(0)) {
        Attack();
      } else if (Input.GetKeyDown("f")) {
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

    public void Move(float inputX) {
      if (inputX > 0) {
        transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        raycastDirection = -1;
      } else if (inputX < 0) {
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        raycastDirection = 1;
      }

      _body2d.velocity = new Vector2(inputX * _speed, _body2d.velocity.y);

      _animator.SetFloat(moveTriggers.AirSpeed, _body2d.velocity.y);
    }

    public void Move() {
      _animator.SetInteger(moveTriggers.AnimState, 2);
    }

    public void Attack() {
      print("ATTACK");
      _animator.SetTrigger(moveTriggers.Attack);
      Invoke(nameof(Hit), .4f);
    }

    private void Hit() {
      RaycastHit2D hit = Physics2D.Raycast(_attackPoint.position, Vector2.right, 5f);

      if (hit.collider != null) {
        print(hit.collider.name);
      }
    }
    public void Idle() {
      _animator.SetInteger(moveTriggers.AnimState, 0);
    }

    public void Hurt() {
      _animator.SetTrigger(moveTriggers.Hurt);
    }

    public void Death() {
      _animator.SetTrigger(!_isDead ? moveTriggers.Death : moveTriggers.Recover);
      _isDead = !_isDead;
    }

    public void Jump() {
      _animator.SetTrigger(moveTriggers.Jump);
      _grounded = false;
      _animator.SetBool(moveTriggers.Grounded, _grounded);
      _body2d.velocity = new Vector2(_body2d.velocity.x, _jumpForce);
      _groundSensor.Disable(0.2f);
    }

    public void CombatIdle() {
      _animator.SetInteger(moveTriggers.AnimState, 1);
    }

    public void ChangeCombatPose() {
      _combatIdle = !_combatIdle;
    }

    public void Grounded() {
      if (!_grounded && _groundSensor.State()) {
        _grounded = true;
        _animator.SetBool(moveTriggers.Grounded, _grounded);
      }

      if (_grounded && !_groundSensor.State()) {
        _grounded = false;
        _animator.SetBool(moveTriggers.Grounded, _grounded);
      }
    }
  }
}