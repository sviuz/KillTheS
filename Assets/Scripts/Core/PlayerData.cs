using Firebase;
using Newtonsoft.Json;
using Other;
using UnityEngine;

namespace Core {
  public class PlayerData : Singleton<PlayerData> {
    private void GetUser(out User user) {
      var json = PlayerPrefs.GetString(PlayerConstants.PlayerData);
      user = JsonConvert.DeserializeObject<User>(json);
    }
    
    public string GetUsername() {
      GetUser(out User user);
      return user.username;
    }
  }
}