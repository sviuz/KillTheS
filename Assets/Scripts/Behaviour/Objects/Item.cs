using Behaviour.Based.Interfaces;
using DG.Tweening;
using UnityEngine;

namespace Behaviour.Objects {
  public class Item : MonoBehaviour, IPickable {
    [SerializeField] private ParticleSystem _particleSystem;
    
    public void Pick() {
      var sq = DOTween.Sequence();
      //TODO animation;
      sq.OnComplete(() => _particleSystem.Play());
    }

    public void Drop() {
      
    }
  }
}