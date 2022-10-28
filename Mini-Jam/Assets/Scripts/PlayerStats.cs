using System;
using UnityEngine;
using UnityEngine.UI;

namespace MiniJam
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private int m_MaxHealth = 100;
        [SerializeField] private int m_MaxBlood = 100;
        [SerializeField] private float m_BloodConsumptionMultiplier = 2f;

        [SerializeField] private RectTransform m_HealthRect;
        [SerializeField] private RectTransform m_BloodRect;
        
        [SerializeField] private Slider m_HealthSlider;
        [SerializeField] private Slider m_BloodSlider;
        
        private float m_CurrentHealth;
        private float m_CurrentBlood;

        private void Start()
        {
            m_CurrentHealth = m_MaxHealth;
            m_CurrentBlood = m_MaxBlood;

            m_HealthSlider.maxValue = m_MaxHealth;
            m_HealthRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, m_MaxHealth);

            m_BloodSlider.maxValue = m_MaxBlood;
            m_BloodRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, m_MaxBlood);
        }

        private void Update()
        {
            ConsumeBlood(Time.deltaTime * m_BloodConsumptionMultiplier);
            
            m_HealthSlider.value = m_CurrentHealth;
            m_BloodSlider.value = m_CurrentBlood;
        }

        public void ConsumeBlood(float amount)
        {
            m_CurrentBlood -= amount;
            if (m_CurrentBlood <= 0)
                Die();
        }

        public void TakeDamage(int amount)
        {
            m_CurrentHealth -= amount;
            if (m_CurrentHealth <= 0)
                Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
