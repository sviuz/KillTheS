using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Panels {
  public class MainPanel : MonoBehaviour {
    [SerializeField]
    private Button _toInGame;
    [SerializeField]
    private Button _toShop;
    [SerializeField]
    private Button _toSettings;
    [SerializeField]
    private Button _toAchievements;

    private List<PanelModel> _panels;

    private void Start() {
      SubscribeButtons();
    }

    private void SubscribeButtons() {
      _toInGame.onClick.AddListener(() => { });
      _toShop.onClick.AddListener(() => { });
      _toSettings.onClick.AddListener(() => { });
      _toAchievements.onClick.AddListener(() => { });
    }
  }
}