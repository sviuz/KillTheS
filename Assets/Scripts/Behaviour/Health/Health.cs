using Other.Constants;
using UnityEngine;

namespace Behaviour.Health {
  public class Health : MonoBehaviour {
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("Components")]
    [SerializeField] private UnityEngine.Behaviour[] components;
    private bool invulnerable;

    private void Awake() {
      currentHealth = startingHealth;
      anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage) {
      if (invulnerable) return;
      Debug.Log(currentHealth.ToString());
      currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

      if (currentHealth > 0) {
        anim.SetTrigger(EnemyConstants.Hurt);
      } else {
        if (dead) return;

        anim.SetTrigger(EnemyConstants.Death);

        foreach (UnityEngine.Behaviour component in components)
          component.enabled = false;

        dead = true;
      }
    }

    public void AddHealth(float _value) {
      currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
  }
}