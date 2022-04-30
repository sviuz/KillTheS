using System;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui.Menu {
  public class MenuUI : MonoBehaviour {
    [SerializeField] private MenuContainer _container;

    private void Start() {
      _container.PlayButton.onClick.AddListener(PlayButtonClick);
      string username = PlayerData.Instance ? PlayerData.Instance.GetUsername() : "Empty Username";
      
      print(username);
      _container.UsernameTMP.SetText(username);
      _container.SettingsButton.onClick.AddListener(SettingsButtonClick);
    }

    private static void GetUsernameText(out string text) {
      try {
        text = "";
      }
      catch (Exception e) {
        throw new Exception(PlayerDataInstanceGetUsernameIsNullOrEmpty());
      }
    }

    private static string PlayerDataInstanceGetUsernameIsNullOrEmpty() => 
      !PlayerData.Instance
      ? "PlayerData.Instance is null"
      : "PlayerData.Instance.GetUsername() is null or empty";

    private void SettingsButtonClick() {
      _container.ShowSettingsButtons();
    }

    private static void PlayButtonClick() {
      SceneManager.LoadScene("Game");
    }
  }
}