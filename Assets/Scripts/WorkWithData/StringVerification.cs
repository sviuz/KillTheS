namespace WorkWithData {
  public static class StringVerification {
    public static bool IsEmailValid(string emailString) {
      try {
        var address = new System.Net.Mail.MailAddress(emailString);
        return address.Address == emailString;
      }
      catch {
        return false;
      }
    }

    
    /// <summary>
    /// Password has to have at least 8 different symbols
    /// </summary>
    /// <param name="pass"></param>
    /// <returns></returns>
    public static bool IsPasswordValid(string pass) =>
      !string.IsNullOrWhiteSpace(pass) && pass.Length >= 8 && pass.Length <= 16;
  }
}