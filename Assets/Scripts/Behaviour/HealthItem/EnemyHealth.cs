using Behaviour.Enemy;
using Level;
using Ui.Level;

namespace Behaviour.HealthItem {
  public class EnemyHealth : Health {
    private EnemyMovement _enemyMovement;

    public override void Awake() {
      base.Awake();
      _enemyMovement = GetComponent<EnemyMovement>();
    }

    public override void Dead() {
      Goal.Instance.IncreaseCurrentGoal();
      LevelUI.Instance.SetGoalText();
      base.Dead();
      _slider.gameObject.SetActive(false);
      _enemyMovement.Dead();
    }
  }
}