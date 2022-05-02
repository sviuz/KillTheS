using JetBrains.Annotations;
using Other.Constants;
using UnityEngine;

namespace Behaviour.Enemy {
  public class MeleeEnemy : MonoBehaviour {
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    //References
    private Animator anim;
    private Health.Health playerHealth;
    private EnemyMovement enemyPatrol;

    private void Awake() {
      anim = GetComponent<Animator>();
      enemyPatrol = GetComponentInParent<EnemyMovement>();
    }

    private void Update() {
      cooldownTimer += Time.deltaTime;

      if (PlayerInSight()) {
        if (cooldownTimer >= attackCooldown) {
          cooldownTimer = 0;
          anim.SetTrigger(EnemyConstants.Attack);
        }
      }

      if (enemyPatrol != null)
        enemyPatrol.enabled = !PlayerInSight();
    }

    private bool PlayerInSight() {
      var bounds = boxCollider.bounds;
      var originVector = bounds.center + transform.right * range * transform.localScale.x * colliderDistance;
      var sizeVector = new Vector3(bounds.size.x * range, bounds.size.y,
        bounds.size.z);
      RaycastHit2D hit = Physics2D.BoxCast(originVector, sizeVector, 0, Vector2.left, 0, playerLayer);

      if (hit.collider != null) {
        playerHealth = hit.transform.GetComponent<Health.Health>();
      }

      return hit.collider != null;
    }

    private void OnDrawGizmos() {
      Gizmos.color = Color.red;
      var bounds = boxCollider.bounds;
      var center = bounds.center + transform.right * range * transform.localScale.x * colliderDistance;
      var size = new Vector3(bounds.size.x * range, bounds.size.y, bounds.size.z);
      Gizmos.DrawWireCube(center, size);
    }

    [UsedImplicitly]
    private void DamagePlayer() {
      if (PlayerInSight())
        playerHealth.TakeDamage(damage);
    }
  }
}