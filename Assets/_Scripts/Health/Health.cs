using System.Collections;
using UnityEngine;

namespace SGGames.Scripts.Healths
{
    /// <summary>
    /// Base class for all health class
    /// </summary>
    public class Health : MonoBehaviour
    {
        [SerializeField] protected float m_maxHealth;
        [SerializeField] protected float m_currentHealth;

        protected bool m_isInvulnerable;
        
        protected virtual void Start()
        {
            m_currentHealth = m_maxHealth;
            UpdateHealthBar();
        }
        
        public virtual void TakeDamage(float damage, float invulnerableDuration)
        {
            if (m_isInvulnerable) return;
            
            m_currentHealth -= damage;
            UpdateHealthBar();
            
            if (m_currentHealth <= 0)
            {
                Kill();
            }
            else
            {
                StartCoroutine(OnInvulnerable(invulnerableDuration));
            }
        }

        protected virtual void UpdateHealthBar()
        {
            
        }

        protected virtual IEnumerator OnInvulnerable(float duration)
        {
            m_isInvulnerable = true;
            yield return new WaitForSeconds(duration);
            m_isInvulnerable = false;
        }

        protected virtual void Kill()
        {
            m_isInvulnerable = true;
            this.gameObject.SetActive(false);
        }
    }
}

