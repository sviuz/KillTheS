using Core;

namespace Level {
  public class Goal : Singleton<Goal> {
    public int _goal = 2;

    private int _currentGoal;

    public void IncreaseCurrentGoal() {
      _currentGoal++;
    }

    public bool IsAbleToWin() => _goal == _currentGoal;
  }
}