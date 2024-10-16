using UnityEngine;

namespace SGGames.Scripts.Character
{
    /// <summary>
    /// Control player movement in 8 directions
    /// </summary>
    public class PlayerMovement : CharacterBehavior
    {
        [SerializeField] private Vector2 m_moveDirection;
        [SerializeField] private float m_movementSpeed;
        [SerializeField] private bool m_isFlipped;

        private Animator m_animator;
        private SpriteRenderer m_spriteRenderer;
        private int m_runningAnimParam= Animator.StringToHash("Running");

        protected override void Start()
        {
            m_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            m_animator = GetComponentInChildren<Animator>();
            base.Start();
        }

        protected override void HandleInput()
        {
            m_moveDirection = Vector2.zero;
            
            if (Input.GetKey(KeyCode.A))
            {
                if (m_characterController.CollisionInfo.LeftCollide) return;
                m_moveDirection.x = -1;
                m_isFlipped = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                if (m_characterController.CollisionInfo.RightCollide) return;
                m_moveDirection.x = 1;
                m_isFlipped = false;
            }

            if (Input.GetKey(KeyCode.W))
            {
                if (m_characterController.CollisionInfo.TopCollide) return;
                m_moveDirection.y = 1;
            }

            if (Input.GetKey(KeyCode.S))
            {
                if (m_characterController.CollisionInfo.BottomCollide) return;
                m_moveDirection.y = -1;
            }
            
            
            base.HandleInput();
        }

        protected override void Update()
        {
            if (!m_isAllow)
            {
                return;
            }
            
            HandleInput();
            UpdateMovement();
            Flip();
            UpdateAnimator();
            base.Update();
        }

        private void Flip()
        {
            m_spriteRenderer.flipX = m_isFlipped;
        }

        private void UpdateMovement()
        {
            m_characterController.SetVelocity(m_moveDirection * (Time.deltaTime * m_movementSpeed));
        }

        protected override void UpdateAnimator()
        {
            m_animator.SetBool(m_runningAnimParam, m_moveDirection!= Vector2.zero);
            base.UpdateAnimator();
        }
    }
}
