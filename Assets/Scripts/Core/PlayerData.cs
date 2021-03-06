using Firebase;
using Newtonsoft.Json;
using Other;
using UnityEngine;

namespace Core {
  public static class PlayerData {
    private static void GetUser(out User user) {
      var json = PlayerPrefs.GetString(PlayerConstants.PlayerData);
      user = JsonConvert.DeserializeObject<User>(json);
    }
    
    public static string GetUsername() {
      GetUser(out User user);
      return user.username;
    }
  }
}