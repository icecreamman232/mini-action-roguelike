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
                m_moveDirection.x = -1;
                m_isFlipped = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                m_moveDirection.x = 1;
                m_isFlipped = false;
            }

            if (Input.GetKey(KeyCode.W))
            {
                m_moveDirection.y = 1;
            }

            if (Input.GetKey(KeyCode.S))
            {
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
            transform.Translate(m_moveDirection * (Time.deltaTime * m_movementSpeed));
        }

        protected override void UpdateAnimator()
        {
            m_animator.SetBool(m_runningAnimParam, m_moveDirection!= Vector2.zero);
            base.UpdateAnimator();
        }
    }
}
