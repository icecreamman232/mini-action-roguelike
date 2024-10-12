using UnityEngine;

namespace SGGames.Scripts.Character
{
    /// <summary>
    /// Base class for character behavior/ability
    /// </summary>
    public class CharacterBehavior : MonoBehaviour
    {
        [SerializeField] protected bool m_isAllow;
        protected CharacterController m_characterController;
        public virtual void ToggleAllow(bool value)
        {
            m_isAllow = value;
        }

        protected virtual void Start()
        {
            m_isAllow = true;
            m_characterController = GetComponent<CharacterController>();
        }

        protected virtual void Update()
        {
            
        }

        protected virtual void HandleInput()
        {
            
        }

        protected virtual void UpdateAnimator()
        {
            
        }
    }
}

