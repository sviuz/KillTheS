using Other;
using Ui.Level;
using UnityEngine;

namespace Level {
  public class Goal : Singleton<Goal> {
    public int _goal = 2;
    public int _currentGoal;

    public void IncreaseCurrentGoal() {
      _currentGoal++;
      IsAbleToWin();
    }

    public void IsAbleToWin() {
      if (_goal == _currentGoal) {
        LevelUI.Instance.Win();
        Debug.Log("WDWAD");
      }

      if (_currentGoal > _goal) {
        Debug.Log("WWWWWWWWWWWWWWWWW");
      }
    }
  }
}