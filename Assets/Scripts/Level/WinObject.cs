using Behaviour;
using Ui.Level;
using UnityEngine;

namespace Level {
  public class WinObject : MonoBehaviour {
    public void Win() {
      if (Goal.Instance.IsAbleToWin()) {
        PlayerMovement.OnSetMovement?.Invoke(false);
        LevelUI.Instance.Win();
      }
    }
  }
}