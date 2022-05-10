using System;
using Other.Constants;
using UnityEngine;
using UnityEngine.UI;

namespace Behaviour.HealthItem {
  public class Health : MonoBehaviour{
    public static Action<float> OnHeal;
    [SerializeField] private float startingHealth;
    [SerializeField] protected Slider _slider;
    [SerializeField] private UnityEngine.Behaviour[] components;

    private float currentHealth { get; set; }
    private Animator anim;
    private bool dead;

    public virtual void Awake() {
      InitParams();
      _slider.maxValue = startingHealth;
      _slider.value = startingHealth;
    }

    private void InitParams() {
      currentHealth = startingHealth;
      anim = GetComponent<Animator>();
      OnHeal += AddHealth;
    }

    private void OnDestroy() {
      OnHeal -= AddHealth;
    }

    public void TakeDamage(float _damage) {
      currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
      _slider.value = currentHealth;
      if (currentHealth > 0) {
        anim.SetTrigger(ObjectConstants.Hurt);
      } else {
        if (dead) return;

        Dead();
      }
    }

    public virtual void Dead() {
      _slider.value = 0;
      anim.SetTrigger(ObjectConstants.Death);

      foreach (UnityEngine.Behaviour component in components)
        component.enabled = false;

      dead = true;
    }

    private void AddHealth(float _value) {
      if (!gameObject.CompareTag("Player")) return;

      currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
      _slider.value = currentHealth;
    }
  }
}