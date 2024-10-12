using SGGames.Scripts.Weapons;
using UnityEngine;

namespace SGGames.Scripts.Character
{
    public class PlayerHandleWeapon : CharacterHandleWeapon
    {
        [SerializeField] private Weapon m_initWeapon;
        [SerializeField] private Vector2 m_shootDirection;

        protected override void Start()
        {
            EquipWeapon(m_initWeapon);
            base.Start();
        }

        public override void EquipWeapon(Weapon newWeapon)
        {
            if (m_currentWeapon != null)
            {
                m_currentWeapon.StopShooting();
                Destroy(m_currentWeapon);
            }

            m_currentWeapon = Instantiate(newWeapon, m_weaponAttachment);
            m_currentWeapon.transform.position = Vector3.zero;
            
            base.EquipWeapon(newWeapon);
        }

        protected override void Update()
        {
            HandleInput();
            base.Update();
        }

        protected override void HandleInput()
        {
            m_shootDirection = Vector2.zero;
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                m_shootDirection.x = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                m_shootDirection.x = 1;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                m_shootDirection.y = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                m_shootDirection.y = -1;
            }

            if (m_shootDirection != Vector2.zero)
            {
                Shoot(m_shootDirection);
            }
            
            
            base.HandleInput();
        }

        protected override void Shoot(Vector2 direction)
        {
            m_currentWeapon.StartShooting(transform.position, direction);
        }
    }
}

