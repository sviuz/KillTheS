using System;
using Firebase.Auth;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WorkWithData;

namespace Firebase.Authentication {
  public class SignUpManager : MonoBehaviour {
    [SerializeField]
    private TMP_InputField _emailInputField;
    [SerializeField]
    private TMP_InputField _passwordInputField;
    [SerializeField]
    private Button _singUpButton;
    private FirebaseAuth _firebaseAuth;
 
    private void Start() {
      _singUpButton.onClick.AddListener(VerifyStrings);
    }

    
    public FirebaseAuth Auth {
      get {
        if (_firebaseAuth == null) {
          // _firebaseAuth = FirebaseAuth.GetAuth(App);
        }

        return _firebaseAuth;
      }
    }

    private FirebaseApp _app;


    private void VerifyStrings() {
      if (StringVerification.IsEmailValid(_emailInputField.text) && StringVerification.IsPasswordValid(_passwordInputField.text)) {
        SignUp(_emailInputField.text, _passwordInputField.text);
      } else {
        
      }
    }
    
    private bool SignUp(string email, string password) {
      var res = false;
      _firebaseAuth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
        if (task.IsCanceled) {
          Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
          res = false;
        }

        if (task.IsFaulted) {
          Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled." + task.Exception);
          res = false;
        }

        FirebaseUser newUser = task.Result;
        Debug.Log($"Firebase user created successfully: {newUser.DisplayName} ({newUser.UserId})");
        res = true;
      });
      return res;
    }
  }
}