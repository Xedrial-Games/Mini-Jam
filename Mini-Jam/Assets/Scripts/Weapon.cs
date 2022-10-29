using UnityEngine;
using UnityEngine.InputSystem;

namespace MiniJam
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform m_FirePoint;
        [SerializeField] private GameObject m_BulletPrefab;

        [SerializeField] private float m_BloodCost = 20f;

        private PlayerStats m_PlayerStats;

        private void Start()
        {
            m_PlayerStats = GetComponent<PlayerStats>();
        }

        public void Shoot(InputAction.CallbackContext _)
        {
            if (m_PlayerStats.ConsumeBlood(m_BloodCost))
                Instantiate(m_BulletPrefab, m_FirePoint.position, m_FirePoint.rotation);
        }
    }
}
