using System.Collections;
using Core.Player;
using Firebase;
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
      Debug.Log("WINWINWIN");
      _winWinResultScreen.Win();
      var index = PlayerPrefs.GetInt("LevelIndex");
      index++;
      PlayerPrefs.SetInt("LevelIndex", index);
      var userData = PlayerDataSaver.LoadData();
      FirebaseDatabaseManager.Instance.SaveData(
        userData.id,
        userData.username,
        userData.password,
        index
      );
    }

    public void Lose() {
      _loseResultScreen.Lose();
    }
  }
}