using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Auth {
  public class AuthenticationMenuContainer : MonoBehaviour {
    [SerializeField] private TMP_Text _usernameInputField;
    [SerializeField] private TMP_InputField _passwordInputField;
    [SerializeField] private Button _saveButton;
    [SerializeField] private TMP_Text _errorTMPText;

    public TMP_Text ErrorTMPText {
      get {
        return _errorTMPText;
      }
    }

    public string PasswordInputField {
      get {
        return _passwordInputField.text;
      }
    }

    public string UsernameInputField {
      get {
        return _usernameInputField.text;
      }
    }

    public Button SaveButton {
      get {
        return _saveButton;
      }
    }
  }
}