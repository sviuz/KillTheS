using Behaviour.Based.Interfaces;
using UnityEngine;

namespace Behaviour.Objects.Items {
  public class HealthItem : Item, IHealable {
    
    
    public void Heal() {
      var health = (float)Random.Range(3, 10);
      Health.Health.OnHeal?.Invoke(health);
    }
  }
}