using System;
using UnityEngine;

namespace SGGames.Scripts.Character
{
    [Serializable]
    public struct CollisionInfo
    {
        public bool TopCollide,BottomCollide;
        public bool LeftCollide,RightCollide;
    }

    [Serializable]
    public struct RaycastOrigins
    {
        public Vector2 TopLeft, TopRight;
        public Vector2 BotLeft, BotRight;
    }
    
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] protected LayerMask m_obstacleLayerMask;
        [SerializeField] protected float m_rayLength;
        [SerializeField] protected int m_horizontalRayNumber;
        [SerializeField] protected int m_verticalRayNumber;
        [SerializeField] protected Vector2 m_velocity;
        [SerializeField] protected RaycastOrigins m_raycastOrigins;
        [SerializeField] protected CollisionInfo m_collisionInfo;
        
        protected float m_horizontalRaySpacing;
        protected float m_verticalRaySpacing;
        protected BoxCollider2D m_boxCollider;
        
        
        public CollisionInfo CollisionInfo => m_collisionInfo;

        protected virtual void Start()
        {
            m_boxCollider = GetComponent<BoxCollider2D>();
            ComputeRaycastSpacing();
        }

        private void Update()
        {
            UpdateRaycastOrigins();
            BotCollision();
            TopCollision();
            LeftCollision();
            RightCollision();
            Move();
        }

        public void SetVelocity(Vector2 velocity)
        {
            m_velocity = velocity;
        }

        public void AddVelocity(Vector2 velocity)
        {
            m_velocity += velocity;
        }

        private void Move()
        {
            transform.Translate(m_velocity);
        }

        private void ComputeRaycastSpacing()
        {
            m_horizontalRaySpacing = m_boxCollider.size.x / (m_horizontalRayNumber - 1);
            m_verticalRaySpacing = m_boxCollider.size.x / (m_verticalRayNumber - 1);
        }

        private void UpdateRaycastOrigins()
        {
            var bounds = m_boxCollider.bounds;
            m_raycastOrigins.BotLeft = new Vector2(bounds.min.x, bounds.min.y);
            m_raycastOrigins.BotRight = new Vector2(bounds.max.x, bounds.min.y);
            
            m_raycastOrigins.TopLeft = new Vector2(bounds.min.x, bounds.max.y);
            m_raycastOrigins.TopRight = new Vector2(bounds.max.x, bounds.max.y);
        }

        private void BotCollision()
        {
            for (int i = 0; i < m_verticalRayNumber; i++)
            {
                var origin = m_raycastOrigins.BotLeft + Vector2.right * (m_verticalRaySpacing * i);
                RaycastHit2D hit2D = Physics2D.Raycast(origin,
                    Vector2.down, m_rayLength, m_obstacleLayerMask);
                
                Debug.DrawRay(origin,Vector2.down * m_rayLength, Color.red);

                if (hit2D.collider != null)
                {
                    m_collisionInfo.BottomCollide = true;
                    return;
                }
                m_collisionInfo.BottomCollide = false;
            }
        }

        private void TopCollision()
        {
            for (int i = 0; i < m_verticalRayNumber; i++)
            {
                var origin = m_raycastOrigins.TopLeft + Vector2.right * (m_verticalRaySpacing * i);
                RaycastHit2D hit2D = Physics2D.Raycast(origin,
                    Vector2.up, m_rayLength, m_obstacleLayerMask);
                
                Debug.DrawRay(origin,Vector2.up * m_rayLength, Color.red);

                if (hit2D.collider != null)
                {
                    m_collisionInfo.TopCollide = true;
                    return;
                }
                m_collisionInfo.TopCollide = false;
            }
        }
        
        private void LeftCollision()
        {
            for (int i = 0; i < m_horizontalRayNumber; i++)
            {
                var origin = m_raycastOrigins.BotLeft + Vector2.up * (m_horizontalRaySpacing * i);
                RaycastHit2D hit2D = Physics2D.Raycast(origin,
                    Vector2.left, m_rayLength, m_obstacleLayerMask);
                
                Debug.DrawRay(origin,Vector2.left * m_rayLength, Color.red);

                if (hit2D.collider != null)
                {
                    m_collisionInfo.LeftCollide  = true;
                    return;
                }
                m_collisionInfo.LeftCollide = false;
            }
        }

        private void RightCollision()
        {
            for (int i = 0; i < m_verticalRayNumber; i++)
            {
                var origin = m_raycastOrigins.BotRight + Vector2.up * (m_verticalRaySpacing * i);
                RaycastHit2D hit2D = Physics2D.Raycast(origin,
                    Vector2.right, m_rayLength, m_obstacleLayerMask);
                
                Debug.DrawRay(origin,Vector2.right * m_rayLength, Color.red);

                if (hit2D.collider != null)
                {
                    m_collisionInfo.RightCollide  = true;
                    return;
                }
                m_collisionInfo.RightCollide = false;
            }
        }
    }
}
