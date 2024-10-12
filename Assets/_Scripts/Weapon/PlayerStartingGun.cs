using UnityEngine;

namespace SGGames.Scripts.Weapons
{
    public class PlayerStartingGun : Weapon
    {
        public override void StartShooting(Vector2 position, Vector2 direction)
        {
            if (m_currentState != WeaponState.IDLE) return;
            
            var bulletGO = m_bulletPooler.GetPooledGameObject();
            var bullet = bulletGO.GetComponent<Bullet>();
            
            bullet.Spawn(position,direction);

            m_currentState = WeaponState.SHOOT;
            
            base.StartShooting(position, direction);
        }
    }
}
