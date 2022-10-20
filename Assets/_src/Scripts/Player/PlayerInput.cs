using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    [RequireComponent(typeof(Player))]
    [RequireComponent(typeof(PlayerWeaponHandler))]
    [RequireComponent(typeof(Move))]
    [RequireComponent(typeof(Rotate))]
    public class PlayerInput : MonoBehaviour
    {
        private Move _move;
        private Rotate _rotate;
        private PlayerWeaponHandler _weapon;

        private PlayerControls _controls;

        private void Awake()
        {
            _move = GetComponent<Move>();
            _rotate = GetComponent<Rotate>();
            _weapon = GetComponent<PlayerWeaponHandler>();
        }

        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new PlayerControls();

                SubscribeToInputEvents();

                _controls.Enable();
            }
        }

        private void OnDisable()
        {
            _move.SetMovementInput(false);
            _weapon.DisableAllShots();
            _rotate.SetRotationDirection(0f);
            
            UnsubscribeFromInputEvents();
            
            _controls.Disable();
        }

        private void SubscribeToInputEvents()
        {
            _controls.Gameplay.Move.performed += _move.SetMovementInput;
            _controls.Gameplay.Move.canceled += _move.SetMovementInput;

            _controls.Gameplay.Rotate.performed += _rotate.SetRotationDirection;
            _controls.Gameplay.Rotate.canceled += _rotate.SetRotationDirection;

            _controls.Gameplay.ShootNormal.performed += _weapon.FireNormalShot;
            _controls.Gameplay.ShootNormal.canceled += _weapon.FireNormalShot;

            _controls.Gameplay.ShootSpecial.performed += _weapon.FireSpecialShot;
            _controls.Gameplay.ShootSpecial.canceled += _weapon.FireSpecialShot;
        }

        private void UnsubscribeFromInputEvents()
        {
            _controls.Gameplay.Move.performed -= _move.SetMovementInput;
            _controls.Gameplay.Move.canceled -= _move.SetMovementInput;

            _controls.Gameplay.Rotate.performed -= _rotate.SetRotationDirection;
            _controls.Gameplay.Rotate.canceled -= _rotate.SetRotationDirection;

            _controls.Gameplay.ShootNormal.performed -= _weapon.FireNormalShot;
            _controls.Gameplay.ShootNormal.canceled -= _weapon.FireNormalShot;

            _controls.Gameplay.ShootSpecial.performed -= _weapon.FireSpecialShot;
            _controls.Gameplay.ShootSpecial.canceled -= _weapon.FireSpecialShot;
        }
    }
}
