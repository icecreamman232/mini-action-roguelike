using SGGames.Scripts.Healths;
using SGGames.Scripts.Managers;
using UnityEngine;

namespace SGGames.Scripts.Weapons
{
    public class DamageHandler : MonoBehaviour
    {
        [SerializeField] protected LayerMask m_targetLayer;
        [SerializeField] protected int m_minDamage;
        [SerializeField] protected int m_maxDamage;
        [SerializeField] protected float m_invulnerableDuration;

        protected virtual int GetDamage()
        {
            return m_minDamage + UnityEngine.Random.Range(m_minDamage, m_maxDamage);
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (LayerManager.IsInLayerMask(other.gameObject.layer, m_targetLayer))
            {
                CauseDamage(other.gameObject);
            }
        }

        protected virtual void CauseDamage(GameObject target)
        {
            var health = target.GetComponent<Health>();
            health.TakeDamage(GetDamage(),m_invulnerableDuration);
        }
    }
}

