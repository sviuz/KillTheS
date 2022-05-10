using System;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui.Menu {
  public class MenuUI : MonoBehaviour {
    [SerializeField] private MenuContainer _container;

    private void Start() {
      _container.PlayButton.onClick.AddListener(PlayButtonClick);
      string username = PlayerData.GetUsername();
      
      print(username);
      _container.UsernameTMP.SetText(username);
      _container.SettingsButton.onClick.AddListener(SettingsButtonClick);
    }

    private void SettingsButtonClick() {
      _container.ShowSettingsButtons();
    }

    private static void PlayButtonClick() {
      SceneManager.LoadScene("Game");
    }
  }
}