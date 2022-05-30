using Core;
using Level;
using TMPro;
using UnityEngine;

namespace Ui.Level {
  public class LevelUI : Singleton<LevelUI> {
    [SerializeField]
    private TMP_Text _goal;

    public void SetGoalText() {
      _goal.text = $"{Goal.Instance._currentGoal.ToString()}/{Goal.Instance._goal.ToString()}";
    }
    
    public void Win() { }

    public void Lose() { }
  }
}