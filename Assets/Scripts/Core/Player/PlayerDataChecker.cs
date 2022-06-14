using System.Collections.Generic;
using System.Linq;
using Firebase;
using static Other.PlayerConstants;

namespace Core.Player {
  public static class PlayerDataChecker {
    
    public static AuthenticationErrorType CheckUserProvidedData(string username, string password) {
      List<string> listOfUsernames = FirebaseDatabaseManager.Instance.GetListOfUsernames();
      List<string> listOfPasswords = FirebaseDatabaseManager.Instance.GetListOfPasswords();

      if (listOfUsernames.Select((t, index) => (t, listOfPasswords[index])).Any(obj => username == obj.Item1 && password == obj.Item2)) {
        return AuthenticationErrorType.AllGood;
      }
      
      if (listOfUsernames.Contains(username)) {
        return AuthenticationErrorType.UsernameAlreadyExist;
      } if (username.Length<6 || username.Length>16 || string.IsNullOrEmpty(username)) {
        return AuthenticationErrorType.NotValidUsername;
      } if (password.Length<6 || string.IsNullOrEmpty(password)) {
        return AuthenticationErrorType.NotValidPassword;
      }

      return AuthenticationErrorType.AllGood;
    }
  }
}