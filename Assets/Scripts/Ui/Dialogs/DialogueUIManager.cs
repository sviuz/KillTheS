using System;
using Core;
using UnityEngine;

namespace Ui.Dialogs {
  public class DialogueUIManager : Singleton<DialogueUIManager> {
    [SerializeField]
    private GameObject _dialogPanel;

    private void Awake() {
      _dialogPanel.SetActive(false);
    }

    public void ShowDialoguePanel(bool show) {
      _dialogPanel.SetActive(show);
    }
  }
}