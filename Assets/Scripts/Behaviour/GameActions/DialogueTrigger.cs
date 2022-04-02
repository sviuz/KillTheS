using System;
using DG.Tweening;
using Managers;
using Ui.Dialogs;
using UnityEngine;

namespace Behaviour.GameActions {
  public class DialogueTrigger : MonoBehaviour {
    public Action OnTrigger;
    public Action OnShowPopUp;
    public Action OnHidePopUp;
    [SerializeField]
    private Dialogue _dialogue;
    [SerializeField]
    private GameObject _popUp;

    private const float _upperPointValue = 2f;
    private const float _lowerPointValue = -2.5f;
    
    private void Awake() {
      OnTrigger += Trigger;
      OnShowPopUp += ShowPopUp;
      OnHidePopUp += HidePopUp;
    }

    private void HidePopUp() {
      _popUp.transform.DOLocalMoveY(_lowerPointValue, .3f);
      DialogueUIManager.Instance.ShowDialoguePanel(false);
    }

    private void OnDestroy() {
      OnTrigger -= Trigger;
      OnShowPopUp -= ShowPopUp;
      OnHidePopUp -= HidePopUp;
    }

    private void Trigger() {
      DialogueUIManager.Instance.ShowDialoguePanel(true);
      DialogueManager.Instance.StartDialogue(_dialogue);
    }

    private void ShowPopUp() {
      _popUp.transform.DOLocalMoveY(_upperPointValue, .3f);
    }
  }
}