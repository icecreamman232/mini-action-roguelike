using SGGames.Scripts.Managers;
using SGGames.Scripts.ScriptableEvent;
using UnityEngine;

namespace SGGames.Scripts.Healths
{
    public class PlayerHealth : Health
    {
        [SerializeField] private FloatEvent m_healthEvent;

        protected override void UpdateHealthBar()
        {
            m_healthEvent.Raise(MathHelpers.Remap(m_currentHealth,0,m_maxHealth,0,1));
            base.UpdateHealthBar();
        }
    }
}

