using UnityEngine;

namespace MiniJam
{
    [RequireComponent(typeof(PlayerMotor))]
    [RequireComponent(typeof(PlayerCombat))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerMotor m_Motor;
        private PlayerCombat m_Combat;

        private float m_Move = 0.0f;
        private float m_MoveY = 0.0f;

        private void Awake()
        {
            m_Motor = GetComponent<PlayerMotor>();
            m_Combat = GetComponent<PlayerCombat>();

            InputSystem.InputSystem.Player.Enable();

            InputSystem.InputSystem.Player.Jump.performed += m_Motor.OnJump;
            InputSystem.InputSystem.Player.Jump.performed += m_Motor.OnWallJump;
            InputSystem.InputSystem.Player.Jump.canceled += m_Motor.OnJumpStop;

            InputSystem.InputSystem.Player.Dash.performed += m_Motor.OnDash;

            var weapon = GetComponent<Weapon>();
            if (weapon)
                InputSystem.InputSystem.Player.Attack.performed += weapon.Shoot;
        }

        private void OnDestroy()
        {
            InputSystem.InputSystem.Player.Jump.performed -= m_Motor.OnJump;
            InputSystem.InputSystem.Player.Jump.performed -= m_Motor.OnWallJump;
            InputSystem.InputSystem.Player.Jump.canceled -= m_Motor.OnJumpStop;

            InputSystem.InputSystem.Player.Dash.performed -= m_Motor.OnDash;

            InputSystem.InputSystem.Player.Attack.performed -= m_Combat.SetAttack;
        }

        private void Update()
        {
            m_Move = InputSystem.InputSystem.Player.Move.ReadValue<float>();
            m_MoveY = InputSystem.InputSystem.Player.MoveY.ReadValue<float>();
        }

        private void FixedUpdate()
        {
            m_Motor.Move(m_Move);
            m_Combat.MoveY = m_MoveY;
        }
    }
}
