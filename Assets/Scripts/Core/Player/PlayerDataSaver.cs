using Firebase;
using Newtonsoft.Json;
using Other;
using Other.Constants;
using UnityEngine;

namespace Core.Player {
  public static class PlayerDataSaver {
    public static void LogIn() {
      PlayerPrefs.SetString(PlayerConstants.IsLoggedIn, Constants.TRUE);
    }
    public static void SaveData(string id, string username, string password) {
      User user = new User(id, username, password);
      PlayerPrefs.SetString(PlayerConstants.PlayerData, JsonConvert.SerializeObject(user));
    }

    public static void LogOut() {
      PlayerPrefs.DeleteKey(PlayerConstants.IsLoggedIn);
      PlayerPrefs.DeleteKey(PlayerConstants.PlayerData);
    }
  }
}