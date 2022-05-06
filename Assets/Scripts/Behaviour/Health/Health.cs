using System;
using Other.Constants;
using UnityEngine;
using UnityEngine.UI;

namespace Behaviour.Health {
  public class Health : MonoBehaviour {
    public static Action<float> OnHeal;
    [SerializeField] private float startingHealth;
    [SerializeField] private Slider _slider;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("Components")]
    [SerializeField] private UnityEngine.Behaviour[] components;
    private bool invulnerable;

    private void Awake() {
      currentHealth = startingHealth;
      anim = GetComponent<Animator>();
      OnHeal += AddHealth;
    }

    private void OnDestroy() {
      OnHeal -= AddHealth;
    }

    public void TakeDamage(float _damage) {
      if (invulnerable) return;
      Debug.Log(currentHealth.ToString());
      currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

      if (currentHealth > 0) {
        anim.SetTrigger(ObjectConstants.Hurt);
      } else {
        if (dead) return;

        anim.SetTrigger(ObjectConstants.Death);

        foreach (UnityEngine.Behaviour component in components)
          component.enabled = false;

        dead = true;
      }
    }

    public void AddHealth(float _value) {
      if (gameObject.CompareTag("Player")) {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
      }
    }
  }
}