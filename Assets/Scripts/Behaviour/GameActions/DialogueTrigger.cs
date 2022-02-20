using System;
using Managers;
using Ui.Dialogs;
using UnityEngine;

namespace Behaviour.GameActions {
  public class DialogueTrigger : MonoBehaviour {
    public Action OnTrigger;
    [SerializeField]
    private Dialogue _dialogue;

    private void Awake() {
      OnTrigger += Trigger;
    }

    private void OnDestroy() {
      OnTrigger -= Trigger;
    }

    private void Trigger() {
      DialogueUIManager.Instance.ShowDialoguePanel(true);
      DialogueManager.Instance.StartDialogue(_dialogue);
    }


  }
}