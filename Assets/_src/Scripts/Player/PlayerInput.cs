using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    [RequireComponent(typeof(Player))]
    [RequireComponent(typeof(Move))]
    [RequireComponent(typeof(Rotate))]
    public class PlayerInput : MonoBehaviour
    {
        private Move _move;
        private Rotate _rotate;
        private ShootBullets _shoot;

        private PlayerControls _controls;

        private void Awake()
        {
            _move = GetComponent<Move>();
            _rotate = GetComponent<Rotate>();
            _shoot = GetComponentInChildren<ShootBullets>();
        }

        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new PlayerControls();

                _controls.Gameplay.Move.performed += _move.SetMovementInput;
                _controls.Gameplay.Move.canceled += _move.SetMovementInput;

                _controls.Gameplay.Rotate.performed += _rotate.SetRotationDirection;
                _controls.Gameplay.Rotate.canceled += _rotate.SetRotationDirection;

                _controls.Gameplay.Shoot.performed += _shoot.SetShootInput;
                _controls.Gameplay.Shoot.canceled += _shoot.SetShootInput;

                _controls.Enable();
            }
        }

        private void OnDisable()
        {
            _controls.Gameplay.Move.performed -= _move.SetMovementInput;
            _controls.Gameplay.Move.canceled -= _move.SetMovementInput;

            _controls.Gameplay.Rotate.performed -= _rotate.SetRotationDirection;
            _controls.Gameplay.Rotate.canceled -= _rotate.SetRotationDirection;

            _controls.Gameplay.Shoot.performed -= _shoot.SetShootInput;
            _controls.Gameplay.Shoot.canceled -= _shoot.SetShootInput;
            
            _controls.Disable();
        }
    }
}
