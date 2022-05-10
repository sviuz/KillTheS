using Behaviour.Based.Interfaces;
using Behaviour.HealthItem;
using DG.Tweening;
using UnityEngine;

namespace Behaviour.Objects.Items {
  public class HealthItem : Item, IHealable {
    public void Heal(float value) {
      Health.OnHeal?.Invoke(value);
    }

    public override void Pick(Vector3 position) {
      base.Pick(position);
      
      var health = (float)Random.Range(3, 10);
      Heal(health);
      Destroy();
    }

    protected override void Destroy() {
      var sq = DOTween.Sequence();
      sq.Append(transform.DOScale(1.3f, 0.4f).SetEase(Ease.InBounce));
      sq.Append(transform.DOScale(0f, 0.2f).SetEase(Ease.Linear));
      sq.OnComplete(() => base.Destroy());
    }
  }
}