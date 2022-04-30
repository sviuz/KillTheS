using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Menu {
  public class MenuContainer : MonoBehaviour {
    #region Variables
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _logoutButton;
    [SerializeField] private Button _soundButton;
    [SerializeField] private TMP_Text _usernameTMP;

    private bool _show = true;
    #endregion

    #region Properties
    public Button SoundButton {
      get {
        return _soundButton;
      }
    }

    public Button LogoutButton {
      get {
        return _logoutButton;
      }
    }

    public Button SettingsButton {
      get {
        return _settingsButton;
      }
    }

    public Button PlayButton {
      get {
        return _playButton;
      }
    }

    public TMP_Text UsernameTMP {
      get {
        return _usernameTMP;
      }
    }
    #endregion
    
    public void ShowSettingsButtons() {
      _soundButton.gameObject.SetActive(_show);
      _logoutButton.gameObject.SetActive(_show);
      _show = !_show;
    }
  }
}