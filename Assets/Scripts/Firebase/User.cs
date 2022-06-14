using Helpers;

namespace Firebase {
  public class User {
    public string id;
    public string username;
    public string password;
    public int lastLevelIndex;

    public User(string _id, string _username, string _password, int index = 0) {
      id = _id;
      username = _username;
      password = _password;
      lastLevelIndex = index;
    }
  }
}