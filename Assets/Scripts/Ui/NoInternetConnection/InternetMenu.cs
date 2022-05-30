using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ui.NoInternetConnection {
  public class InternetMenu : MonoBehaviour {
    [SerializeField]
    private Button _retryButton;

    private void Start() {
      _retryButton.onClick.AddListener(Retry);
    }

    private static void Retry() {
      if (Application.internetReachability != NetworkReachability.NotReachable) {
        SceneManager.LoadScene("Authorization");
      }
    }
  }
}