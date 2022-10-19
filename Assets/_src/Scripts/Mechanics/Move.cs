using UnityEngine;
using UnityEngine.InputSystem;

namespace PedroAurelio.PainfulSmile
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Move : MonoBehaviour
    {
        [Header("General Settings")]
        [SerializeField, Range(0f, 10f)] private float moveSpeed = 1f;
        [SerializeField, Range(0f, 20f)] private float posAccel = 8f;
        [SerializeField, Range(0f, 20f)] private float negAccel = 15f;
        [SerializeField, Range(0f, 15f)] private float maxPosSpeed = 3f;

        [Header("Backwards Settings")]
        [SerializeField] private bool canGoBackwards = false;
        [SerializeField, Range(0f, 1f)] private float backwardsSpeedMultiplier = 0.5f;
        [SerializeField, Range(0f, 15f)] private float maxNegSpeed = 1.5f;

        private float _movementInput;

        private Rigidbody2D _rigidbody;

        private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();
        
        private void FixedUpdate() => ApplyMovementForce();

        private void ApplyMovementForce()
        {
            Vector2 targetSpeed;
            float acceleration;

            if (_movementInput != 0)
            {
                targetSpeed = moveSpeed * transform.right;
                acceleration = posAccel;
                
                targetSpeed = _movementInput < 0f && canGoBackwards 
                    ? _movementInput * backwardsSpeedMultiplier *  targetSpeed
                    : targetSpeed;
            }
            else
            {
                targetSpeed = -_rigidbody.velocity;
                acceleration = negAccel;
            }

            _rigidbody.AddForce(acceleration * targetSpeed);

            var maxSpeed = _movementInput >= 0f ? maxPosSpeed : maxNegSpeed;
            var clampedVelocity = Vector2.ClampMagnitude(_rigidbody.velocity, maxSpeed);
            _rigidbody.velocity = clampedVelocity;
        }

        public void SetMovementInput(float value) => _movementInput = value;
        public void SetMovementInput(bool value) => _movementInput = value ? 1f : 0f;

        public void SetMovementInput(InputAction.CallbackContext ctx)
        {
            switch (ctx.phase)
            {
                case InputActionPhase.Performed: SetMovementInput(ctx.ReadValue<float>()); break;
                case InputActionPhase.Canceled: SetMovementInput(0f); break;
                default: break;
            }
        }
    }
}
