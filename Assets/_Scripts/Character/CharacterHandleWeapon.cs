using SGGames.Scripts.Weapons;
using UnityEngine;

namespace SGGames.Scripts.Character
{
    /// <summary>
    /// Base class to handle weapon
    /// </summary>
    public class CharacterHandleWeapon : CharacterBehavior
    {
        [SerializeField] protected Transform m_weaponAttachment;
        [SerializeField] protected Weapon m_currentWeapon;


        public virtual void EquipWeapon(Weapon newWeapon)
        {
            
        }
        
        protected virtual void Shoot(Vector2 direction)
        {
            
        }
    }
}
