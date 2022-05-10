using System;
using UnityEngine;

namespace Level {
  public class Goal : MonoBehaviour {
    public static Action OnGoal;
    [SerializeField] private int _goal;

    private int _currentGoal;
    
    private void Awake() {
      OnGoal += IncreaseCurrentGoal;
    }

    private void IncreaseCurrentGoal() {
      _currentGoal++;

      if (_currentGoal == _goal) {
        LevelManager.OnWin?.Invoke();
      }
    }
  }
}