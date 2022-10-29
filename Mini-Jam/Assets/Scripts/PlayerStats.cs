using System;
using UnityEngine;
using UnityEngine.UI;

namespace MiniJam
{
    public class PlayerStats : MonoBehaviour
    {
        public float CurrentHealth { get; private set; }
        public float CurrentBlood { get; private set; }
        
        [SerializeField] private int m_MaxHealth = 100;
        [SerializeField] private int m_MaxBlood = 100;
        [SerializeField] private float m_BloodConsumptionMultiplier = 2f;

        [SerializeField] private RectTransform m_HealthRect;
        [SerializeField] private RectTransform m_BloodRect;
        
        [SerializeField] private Slider m_HealthSlider;
        [SerializeField] private Slider m_BloodSlider;

        private void Start()
        {
            CurrentHealth = m_MaxHealth;
            CurrentBlood = m_MaxBlood;

            m_HealthSlider.maxValue = m_MaxHealth;
            m_HealthRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, m_MaxHealth);

            m_BloodSlider.maxValue = m_MaxBlood;
            m_BloodRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, m_MaxBlood);
        }

        private void Update()
        {
            ConsumeBlood(Time.deltaTime * m_BloodConsumptionMultiplier);
            
            m_HealthSlider.value = CurrentHealth;
            m_BloodSlider.value = CurrentBlood;
        }

        public bool ConsumeBlood(float amount)
        {
            if (CurrentBlood < amount)
                return false;
            
            CurrentBlood -= amount;
            return true;
        }

        public void TakeDamage(int amount)
        {
            CurrentHealth -= amount;
            if (CurrentHealth <= 0)
                Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
