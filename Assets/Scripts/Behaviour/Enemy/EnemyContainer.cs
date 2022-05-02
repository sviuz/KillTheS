using UnityEngine;
using static Other.Constants.Constants;

namespace Behaviour.Enemy {
  public class EnemyContainer : MonoBehaviour {
    [SerializeField] private float _groundCheckDistance;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _hitDuration;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameObject _alive;
    [SerializeField] private Transform _groundDetector;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Vector2 _hitSpeed;
    [SerializeField] private Animator _anim;
    [SerializeField] private Transform[] _targets;
    [SerializeField] private float _minDistanceToTarget;

    private Vector3 _currentTarget;
    private float _currentHealth;
    private float _hitStartTime;
    private int _facingDirection = 1;
    private int _damageDirection;
    private int _currentTargetIndex;
    private Vector2 _movement;
    private bool _groundChecked;
    private bool _wallChecked;
    private State _currentState;
    
    public int CurrentTargetIndex {
      get {
        return _currentTargetIndex;
      }
      set {
        _currentTargetIndex = value;
      }
    }
    
    public float MinDistanceToTarget {
      get {
        return _minDistanceToTarget;
      }
      set {
        _minDistanceToTarget = value;
      }
    }
    
    public Transform[] Targets {
      get {
        return _targets;
      }
      set {
        _targets = value;
      }
    }

    public Vector3 CurrentTarget {
      get {
        return _currentTarget;
      }
      set {
        _currentTarget = value;
      }
    }
    
    public float CurrentHealth {
      get {
        return _currentHealth;
      }
      set {
        _currentHealth = value;
      }
    }

    public float HitStartTime {
      get {
        return _hitStartTime;
      }
      set {
        _hitStartTime = value;
      }
    }

    public int FacingDirection {
      get {
        return _facingDirection;
      }
      set {
        _facingDirection = value;
      }
    }

    public int DamageDirection {
      get {
        return _damageDirection;
      }
      set {
        _damageDirection = value;
      }
    }

    public Vector2 Movement {
      get {
        return _movement;
      }
      set {
        _movement = value;
      }
    }

    public bool GroundChecked {
      get {
        return _groundChecked;
      }
      set {
        _groundChecked = value;
      }
    }

    public bool WallChecked {
      get {
        return _wallChecked;
      }
      set {
        _wallChecked = value;
      }
    }

    public State CurrentState {
      get {
        return _currentState;
      }
      set {
        _currentState = value;
      }
    }

    
    
    public Rigidbody2D Rb {
      get {
        return _rb;
      }
    }

    public GameObject Alive {
      get {
        return _alive;
      }
    }

    public Transform GroundDetector {
      get {
        return _groundDetector;
      }
    }

    public LayerMask GroundMask {
      get {
        return _groundMask;
      }
    }

    public float GroundCheckDistance {
      get {
        return _groundCheckDistance;
      }
    }

    public float Speed {
      get {
        return _speed;
      }
    }

    public float MaxHealth {
      get {
        return _maxHealth;
      }
    }

    public float HitDuration {
      get {
        return _hitDuration;
      }
    }

    public Vector2 HitSpeed {
      get {
        return _hitSpeed;
      }
    }

    public Animator Anim {
      get {
        return _anim;
      }
    }
  }
}