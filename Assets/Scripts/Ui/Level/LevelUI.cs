using System.Collections;
using Core;
using Level;
using Other;
using ResultScreens;
using TMPro;
using UnityEngine;

namespace Ui.Level {
  public class LevelUI : Singleton<LevelUI> {
    [SerializeField]
    private TMP_Text _goal;
    [SerializeField]
    private ResultScreen _winWinResultScreen;
    [SerializeField]
    private ResultScreen _loseResultScreen;

    private IEnumerator Start() {
      yield return new WaitForSeconds(1);
      SetGoalText();
    }
    
    public void SetGoalText() {
      _goal.text = $"{Goal.Instance._currentGoal.ToString()}/{Goal.Instance._goal.ToString()}";
    }

    public void Win() {
      _winWinResultScreen.Win();
    }

    public void Lose() {
      _loseResultScreen.Lose();
    }
  }
}