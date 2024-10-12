using System;
using SGGames.Scripts.Managers;
using UnityEngine;


namespace SGGames.Scripts.Weapons
{

    public enum WeaponState
    {
        IDLE,
        SHOOT,
        DELAY,
        STOP,
    }
    
    /// <summary>
    /// Base class for all weapon
    /// </summary>
    public class Weapon : MonoBehaviour
    {
        [SerializeField] protected WeaponState m_currentState;
        [SerializeField] protected float m_delayBetween2Shots;
        [SerializeField] protected ObjectPooler m_bulletPooler;

        protected float m_delayTimer;
        
        public virtual void StartShooting(Vector2 position, Vector2 direction)
        {
            
        }

        public virtual void StopShooting()
        {
            
        }

        protected virtual void Update()
        {
            UpdateWeaponState();
        }

        protected virtual void UpdateWeaponState()
        {
            switch (m_currentState)
            {
                case WeaponState.IDLE:
                    CaseIdle();
                    break;
                case WeaponState.SHOOT:
                    CaseShoot();
                    break;
                case WeaponState.DELAY:
                    CaseDelay();
                    break;
                case WeaponState.STOP:
                    CaseStop();
                    break;
            }
        }

        protected virtual void CaseIdle()
        {
            
        }
        
        protected virtual void CaseShoot()
        {
            m_delayTimer = m_delayBetween2Shots;
            m_currentState = WeaponState.DELAY;
        }
        
        protected virtual void CaseDelay()
        {
            m_delayTimer -= Time.deltaTime;
            if (m_delayTimer <= 0)
            {
                m_delayTimer = 0;
                m_currentState = WeaponState.STOP;
            }
        }
        protected virtual void CaseStop()
        {
            m_currentState = WeaponState.IDLE;
        }
    }
}

