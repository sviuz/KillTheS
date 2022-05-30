using Other;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Player {
  public class AuthenticationChecker:MonoBehaviour {
    private void Start() {
      if (Application.internetReachability == NetworkReachability.NotReachable) {
        SceneManager.LoadScene("NoInternetConnection");
        return;
      }
      SceneManager.LoadScene(PlayerPrefs.HasKey(PlayerConstants.IsLoggedIn) ? "Menu" : "Authorization");
    }
  }
}