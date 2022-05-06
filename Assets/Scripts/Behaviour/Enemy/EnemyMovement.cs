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

    private void MoveInDirection(int _direction) {
      _idleTimer = 0;
      _anim.SetTrigger(ObjectConstants.Move);

      _enemy.localScale = new Vector3(Mathf.Abs(_initScale.x) * _direction * _facingDirection,
        _initScale.y, _initScale.z);

      var position = _enemy.position;
      position = new Vector3(position.x + Time.deltaTime * _direction * _speed,
        position.y, position.z);
      _enemy.position = position;
    }
  }
}