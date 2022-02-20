using System.Collections.Generic;
using Behaviour.GameActions;
using Ui.Dialogs;
using UnityEngine;

namespace Managers {
  public class DialogueManager : MonoBehaviour {
    public static DialogueManager Instance;
    private Queue<string> _dialogs;

    [SerializeField]
    private DialoguePanel _dialoguePanel;

    private void Awake() {
      if (Instance == null) {
        Instance = this;
      } else {
        Destroy(gameObject);
      }
    }

    private void Start() {
      _dialogs = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {
      _dialoguePanel.SetName(dialogue._name);
      ClearDialoguesQueue(dialogue);

      DisplayNextSentence();
    }
    
    private void ClearDialoguesQueue(Dialogue dialogue) {
      _dialogs.Clear();

      foreach (string obj in dialogue._sentences) {
        _dialogs.Enqueue(obj);
      }
    }

    private void DisplayNextSentence() {
      if (_dialogs.Count == 0) {
        EndDialogue();
        return;
      }

      string sentence = _dialogs.Dequeue();
      _dialoguePanel.SetDialogue(sentence);
    }

    private static void EndDialogue() {
      print("End Conversation");
    }
  }
}