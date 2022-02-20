using System;
using UnityEngine;

namespace Ui {
  public class InGameUiManager : MonoBehaviour {
    public static InGameUiManager Instance;
    
    [SerializeField]
    private GameObject _newQuestIndicator;

    private void Awake() {
      InitializeInstance();
    }

    private void InitializeInstance() {
      if (Instance == null) {
        Instance = this;
      } else {
        Destroy(gameObject);
      }
    }

    public void ShowNewQuestIndicator(bool show) {
      _newQuestIndicator.SetActive(show);
    }
  }
}