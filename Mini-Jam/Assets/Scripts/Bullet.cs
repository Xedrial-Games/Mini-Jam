using UnityEngine;

namespace MiniJam
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float m_Speed = 20f;
        [SerializeField] private float m_TimeBeforeDestroy = 5f;

        private Rigidbody2D m_Rigidbody2D;

        private void Start()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Rigidbody2D.velocity = transform.right * m_Speed;
            
            Destroy(gameObject, m_TimeBeforeDestroy);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Destroy(gameObject);
        }
    }
}