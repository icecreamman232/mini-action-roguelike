using UnityEngine;

namespace SGGames.Scripts.Weapons
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] protected Vector2 m_moveDirection;
        [SerializeField] protected float m_speed;
        [SerializeField] protected float m_range;
        [SerializeField] protected LayerMask m_obstacleLayer;
        
        protected bool m_isFired;
        protected float m_travelledDistance;
        protected Vector2 m_startPosition;
        
        public virtual void Spawn(Vector3 spawnPosition, Vector2 direction)
        {
            transform.position = spawnPosition;
            m_moveDirection = direction;
            m_isFired = true;
            m_travelledDistance = 0;
            m_startPosition = transform.position;
        }

        protected virtual void Update()
        {
            if (!m_isFired) return;
            
            transform.Translate(m_moveDirection * (Time.deltaTime * m_speed));
            
            m_travelledDistance = Vector2.Distance(m_startPosition, transform.position);
            if (m_travelledDistance >= m_range)
            {
                SelfDestroy();
            }
        }

        protected virtual void SelfDestroy()
        {
            m_isFired = false;
            this.gameObject.SetActive(false);
        }
    }
}
    

