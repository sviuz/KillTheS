using TMPro;
using UnityEngine;

namespace Ui.Dialogs {
  public class DialoguePanel : MonoBehaviour {
    [SerializeField]
    private TMP_Text _name;
    [SerializeField]
    private TMP_Text _dialogue;

    public void SetName(string name) {
      _name.text = name;
    }

    public void SetDialogue(string dialogue) {
      _dialogue.text = dialogue;
    }
  }
}