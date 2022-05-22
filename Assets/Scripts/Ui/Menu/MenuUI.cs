using System;
using Core;
using Core.Player;
using Other;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui.Menu {
  public class MenuUI : MonoBehaviour {
    [SerializeField] private MenuContainer _container;

    private void Start() {
      _container.PlayButton.onClick.AddListener(PlayButtonClick);
      string username = PlayerData.GetUsername();
      
      _container.UsernameTMP.SetText(username);
      _container.SettingsButton.onClick.AddListener(SettingsButtonClick);
      _container.ExitGameButton.onClick.AddListener(Application.Quit);
      _container.LogoutButton.onClick.AddListener(LogOutClick);
    }

    private static void LogOutClick() {
      PlayerDataSaver.LogOut();
      SceneManager.LoadScene("Authorization");
    }

    private void SettingsButtonClick() {
      _container.ShowSettingsButtons();
    }

    private static void PlayButtonClick() {
      SceneManager.LoadScene("Game");
    }
  }
}