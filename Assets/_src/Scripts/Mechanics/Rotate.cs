using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PedroAurelio.PainfulSmile
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Rotate : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Range(10f, 150f)] private float rotationSpeed = 50f;
        [SerializeField, Range(0f, 10f)] private float posAccel = 3f;
        [SerializeField, Range(0f, 10f)] private float negAccel = 1.5f;

        private float _rotationDirection;

        private Rigidbody2D _rigidbody;

        private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();

        private void FixedUpdate() => ApplyRotationVelocity();

        private void ApplyRotationVelocity()
        {
            if (_rotationDirection != 0f)
                _rigidbody.angularVelocity = Mathf.MoveTowards(_rigidbody.angularVelocity, rotationSpeed * _rotationDirection, posAccel);
            else
                _rigidbody.angularVelocity = Mathf.MoveTowards(_rigidbody.angularVelocity, 0f, negAccel);
        }

        public void SetRotationDirection(float direction) => _rotationDirection = direction;
        public void SetRotationDirection(RotationDirection direction)
        {
            switch (direction)
            {
                case RotationDirection.Left: SetRotationDirection(1f); break;
                case RotationDirection.Right: SetRotationDirection(-1f); break;
            }
        }

        public void SetRotationDirection(InputAction.CallbackContext ctx)
        {
            switch (ctx.phase)
            {
                case InputActionPhase.Performed: SetRotationDirection(ctx.ReadValue<float>()); break;
                case InputActionPhase.Canceled: SetRotationDirection(0f); break;
                default: break;
            }
        }
    }

    public enum RotationDirection
    {
        Left,
        Right
    }
}
