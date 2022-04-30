using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Behaviour {
  public class EnemyController: MonoBehaviour {
  private enum State {
    walking,
    hit,
    dead
  }

  [SerializeField] private Transform groundDetector;
  [SerializeField] private Transform wallDetector;
  [SerializeField] private LayerMask _groundMask;
  [SerializeField] private float _groundCheckDistance;
  
  private bool groundChecked;
  private bool wallChecked;
  
  private State _currentState;

  #region Update
  private void Update() {
    CheckingTheState();
  }

  private void CheckingTheState() {
    if (_currentState == State.walking) {
      UpdateWalkingState();
    } else if (_currentState == State.hit) {
      UpdateHitState();
    } else if (_currentState == State.dead) {
      UpdateDeadState();
    }
  }
  #endregion

  #region WalkingState
  private void EnterWalkingState() { }

  private void UpdateWalkingState() { }

  private void ExitWalkingState() { }
  #endregion

  #region HitState
  private void EnterHitState() { }

  private void UpdateHitState() { }

  private void ExitHitState() { }
  #endregion

  #region DeadState
  private void EnterDeadState() { }

  private void UpdateDeadState() { }

  private void ExitDeadState() { }
  #endregion

  private void SwitchState(State _state) {
    ExitState(_state);
    _currentState = _state;
    EnterState(_state);
  }

  private void EnterState(State state) {
    switch (state) {
      case State.walking:
        EnterWalkingState();
        break;
      case State.hit:
        EnterHitState();
        break;
      case State.dead:
        EnterDeadState();
        break;
    }
  }

  private void ExitState(State _state) {
    switch (_currentState) {
      case State.walking:
        ExitWalkingState();
        break;
      case State.hit:
        ExitHitState();
        break;
      case State.dead:
        ExitDeadState();
        break;
    }
  }
  }
}