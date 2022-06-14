using Level;
using ResultScreens;
using Ui.Level;

namespace Behaviour.HealthItem {
  public class PlayerHealth : Health {
    public override void Dead() {
      base.Dead();
      PlayerMovement.OnDeath?.Invoke();
      LevelUI.Instance.Lose();
    }
  }
}