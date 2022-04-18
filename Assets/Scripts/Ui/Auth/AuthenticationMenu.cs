using System;
using Core.Player;
using Firebase;
using Helpers;
using Other;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui.Auth {
  public class AuthenticationMenu : MonoBehaviour {
    [SerializeField] private AuthenticationMenuContainer _container;

    private void Awake() {
      if (_container == null) {
        _container = GetComponent<AuthenticationMenuContainer>();
      }
    }

    private void Start() {
      _container.SaveButton.onClick.AddListener(SaveButtonClick);
    }

    private void SaveButtonClick() {
      PlayerConstants.AuthenticationErrorType taskResult = 
        PlayerDataChecker.CheckUserProvidedData(
        _container.UsernameInputField,
        _container.PasswordInputField);

      switch (taskResult) {
        case PlayerConstants.AuthenticationErrorType.UsernameAlreadyExist:
          _container.ErrorTMPText.text = "Username is already exists.";
          break;
        case PlayerConstants.AuthenticationErrorType.NotValidUsername:
          _container.ErrorTMPText.text = "Your username is too short or too long.";
          break;
        case PlayerConstants.AuthenticationErrorType.NotValidPassword:
          _container.ErrorTMPText.text = "Your password is weak";
          break;
        case PlayerConstants.AuthenticationErrorType.AllGood:
          SuccessfulDataInput();
          break;
        default:
          _container.ErrorTMPText.text = "Internal Error";
          break;
      }
    }

    private void SuccessfulDataInput() {
      string id = DataGenerator.GenerateId(10);
      FirebaseDatabaseManager.Instance.SaveData(
        id,
        _container.UsernameInputField,
        _container.PasswordInputField
      );
      PlayerDataSaver.LogIn();
      PlayerDataSaver.SaveData(
        id,
        _container.UsernameInputField,
        _container.PasswordInputField);
      SceneManager.LoadScene("Menu");
    }
  }
}