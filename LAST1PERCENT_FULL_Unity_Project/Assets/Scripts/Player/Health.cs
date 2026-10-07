using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public UnityEvent onDeath;
    public float Current { get; private set; }

    private void Awake() => Current = maxHealth;

    public void Damage(float amount)
    {
        if (amount <= 0 || Current <= 0) return;
        Current = Mathf.Max(0,Current-amount);
        if (Current <= 0) onDeath?.Invoke();
    }

    public void Heal(float amount) => Current = Mathf.Min(maxHealth,Current+Mathf.Max(0,amount));
}
