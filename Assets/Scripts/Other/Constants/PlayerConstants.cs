namespace Other {
  public static class PlayerConstants {
    public const string IsLoggedIn = nameof(IsLoggedIn);
    public const string PlayerData = nameof(PlayerData);

    public enum AuthenticationErrorType {
      UsernameAlreadyExist,
      NotValidUsername,
      NotValidPassword,
      AllGood
    }
    
    public enum PasswordScore {
      Blank = 0,
      VeryWeak = 1,
      Weak = 2,
      Medium = 3,
      Strong = 4,
      VeryStrong = 5
    }
  }
}