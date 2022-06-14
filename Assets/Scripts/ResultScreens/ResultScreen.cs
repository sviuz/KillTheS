using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ResultScreens {
  public class ResultScreen : MonoBehaviour, IWinResultScreen, ILoseResultScreen {
    private enum ResultType {
      Win,
      Lose
    }

    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private ResultType type;
    [SerializeField]
    private Button _homeButton;
    [SerializeField]
    private Button _additionalButton;

    private void Start() {
      _prefab.SetActive(false);
    }

    public void Win() {
      _prefab.SetActive(true);
      SubscribeButtons();
    }

    public void Lose() {
      _prefab.SetActive(true);
      SubscribeButtons();
    }

    private void SubscribeButtons() {
      _homeButton.onClick.AddListener(HomeButtonClick);

      switch (type) {
        case ResultType.Win:
          _additionalButton.onClick.AddListener(NextLevelClick);
          break;
        case ResultType.Lose:
          _additionalButton.onClick.AddListener(RestartLevelClick);
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private static void RestartLevelClick() {
      int scene = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(scene);
    }

    private void NextLevelClick() {
      var index = PlayerPrefs.GetInt("LevelIndex", 0);
      SceneManager.LoadScene(index);
    }

    private static void HomeButtonClick() {
      SceneManager.LoadScene("Menu");
    }
  }
}