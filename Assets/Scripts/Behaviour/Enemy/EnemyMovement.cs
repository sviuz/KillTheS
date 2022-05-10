using Other.Constants;
using UnityEngine;

namespace Behaviour.Enemy {
  public class EnemyMovement : MonoBehaviour {
    [SerializeField] private Transform _leftEdge;
    [SerializeField] private Transform _rightEdge;
    [SerializeField] private Transform _enemy;
    [SerializeField] private float _speed;
    [SerializeField] private float _idleDuration;
    [SerializeField] private Animator _anim;
    [SerializeField] private BoxCollider2D _boxCollider;
    [SerializeField] private Rigidbody2D _rigidbody;
    private int _facingDirection = -1;
    private float _idleTimer;
    private Vector3 _initScale;
    private bool _moveLeft = true;

    private void Awake() {
      _initScale = _enemy.localScale;
    }

    private void Update() {
      if (_moveLeft) {
        if (_enemy.position.x >= _leftEdge.position.x) {
          MoveInDirection(-1);
        } else {
          DirectionChange();
        }
      } else {
        if (_enemy.position.x <= _rightEdge.position.x) {
          MoveInDirection(1);
        } else {
          DirectionChange();
        }
      }
    }

    private void OnDisable() {
      _anim.SetBool(ObjectConstants.Move, false);
    }

    private void DirectionChange() {
      _anim.SetBool(ObjectConstants.Move, false);
      _idleTimer += Time.deltaTime;

      if (_idleTimer > _idleDuration) {
        _moveLeft = !_moveLeft;
      }
    }

    public void Dead() {
      _rigidbody.bodyType = RigidbodyType2D.Static;
      _boxCollider.enabled = false;
    }

    private void MoveInDirection(int _direction) {
      _idleTimer = 0;
      _anim.SetTrigger(ObjectConstants.Move);
      Vector3 position = _enemy.position;
      float x = position.x + Time.deltaTime * _direction * _speed;
      float xDir = Mathf.Abs(_initScale.x) * _direction * _facingDirection;

      position = new Vector3(x, position.y, position.z);
      
      _enemy.localScale = new Vector3(xDir, _initScale.y, _initScale.z);
      _enemy.position = position;
    }
  }
}