using UnityEngine;

namespace AutumnForest
{
    public class CreatureHealth : Health
    {
        [SerializeField] private bool destroyOnDie = true; 

        public override void DecreaseMaximumHealth(int damagePoints)
        {
            maximumHealth -= damagePoints;
            onHealthChange.Invoke(currentHealth, maximumHealth);
        }

        public override void Heal(int healPoints)
        {
            currentHealth += healPoints;
            onHeal.Invoke(currentHealth, maximumHealth);
            onHealthChange.Invoke(currentHealth, maximumHealth);

            if (currentHealth > maximumHealth)
                currentHealth = maximumHealth;
        }

        public override void IncreaseMaximumHealth(int healPoints)
        {
            maximumHealth += healPoints;
            onHealthChange.Invoke(currentHealth, maximumHealth);
        }

        public override void TakeHit(int damagePoints)
        {
            currentHealth -= damagePoints;
            onTakeHit.Invoke(currentHealth, maximumHealth);
            onHealthChange.Invoke(currentHealth, maximumHealth);

            if (currentHealth <= 0)
            {
                onDie.Invoke();
                if (destroyOnDie) Destroy(gameObject);
            }
        }
    }
}