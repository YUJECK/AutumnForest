using UnityEngine;
using UnityEngine.UI;

namespace AutumnForest
{
    public abstract class HealthBar : MonoBehaviour
    {
        //health bar components
        [SerializeField] private Slider healthBar;
        [SerializeField] private SpriteRenderer healthBarIcon;
        [SerializeField] private Text healthBarText;
        //health target
        private Health healthTarget;


        //methods
        public virtual void SetPreset(HealthBarPreset healthBarPreset)
        {
            if (healthBarPreset != null)
            {
                //fill all fields
                healthTarget = healthBarPreset.HealthTarget;
                healthBarIcon.sprite = healthBarPreset.HealthBarIcon;
                healthBarText.text = healthBarPreset.HealthBarName;

                healthTarget.onHealthChange.AddListener(UpdateHealthBar);
                //update health bar to new health params
                UpdateHealthBar(healthTarget.CurrentHealth, healthTarget.MaximumHealth);
            }
            else Debug.LogError($"Null reference. {healthBarPreset.name} is null");
        }
        private void UpdateHealthBar(int currentHealth, int maximumHealth)
        {
            if (healthBar != null)
            {
                healthBar.value = currentHealth;
                healthBar.maxValue = maximumHealth;
            }
            else Debug.LogError($"Null reference. {healthBar.name} is null");
        }
    }
}