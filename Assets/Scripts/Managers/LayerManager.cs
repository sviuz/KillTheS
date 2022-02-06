using System;
using Other;
using UnityEngine;

namespace Managers {
  public class LayerManager : MonoBehaviour {
    public static LayerManager instance;

    [SerializeField]
    private RectTransform _dragLayerRect;

    private void Awake() {
      if (instance) {
        Destroy(gameObject);
      } else {
        instance = this;
      }
    }

    public RectTransform GetRectByTag(Constants.TagsEnum tag) {
      if (tag == Constants.TagsEnum.Drag) {
        return _dragLayerRect;
      } else {
        return new RectTransform();
      }
    }
  }
}