using Behaviour.Enemy;

namespace Behaviour.HealthItem {
  public class EnemyHealth : Health {
    private EnemyMovement _enemyMovement;

    public override void Awake() {
      base.Awake();
      _enemyMovement = GetComponent<EnemyMovement>();
    }

    public override void Dead() {
      base.Dead();
      _slider.gameObject.SetActive(false);
      _enemyMovement.Dead();
    }
  }
}