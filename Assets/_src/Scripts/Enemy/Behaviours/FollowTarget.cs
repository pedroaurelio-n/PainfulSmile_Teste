using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    [RequireComponent(typeof(Enemy))]
    [RequireComponent(typeof(Move))]
    [RequireComponent(typeof(Rotate))]
    public class FollowTarget : BaseBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float maxDistanceFromTarget;
        [SerializeField] private bool startLookingAtTarget;
        [SerializeField, Range(0f, 1f)] private float rotationThreshold = 0.1f;

        private Move _move;
        private Rotate _rotate;

        private void OnValidate()
        {
            if (maxDistanceFromTarget < 0f)
                maxDistanceFromTarget = 0f;
        }

        private void Awake()
        {
            _move = GetComponent<Move>();
            _rotate = GetComponent<Rotate>();
        }

        protected override void Start()
        {
            base.Start();
            
            if (startLookingAtTarget)
                FaceTarget();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            if (maxDistanceFromTarget == 0f)
                _move.SetMovementInput(true);

            if (startLookingAtTarget)
                FaceTarget();
        }

        private void Update()
        {
            CheckTargetDistance();
            RotateTowardsTarget();
        }

        private void CheckTargetDistance()
        {
            if (maxDistanceFromTarget == 0f || _Target == null)
                return;
            
            var distanceToTarget = Vector2.Distance(_Target.position, transform.position);

            if (distanceToTarget > maxDistanceFromTarget)
                _move.SetMovementInput(true);
            else
                _move.SetMovementInput(false);
        }

        private void RotateTowardsTarget()
        {
            if (_Target == null)
                return;

            var directionToTarget = _Target.position - transform.position;
            var dotProduct = Vector2.Dot(transform.up, directionToTarget.normalized);

            if (Mathf.Abs(dotProduct) < rotationThreshold)
            {
                _rotate.SetRotationDirection(0f);
                return;
            }

            if (dotProduct >= 0f)
                _rotate.SetRotationDirection(RotationDirection.Left);
            else
                _rotate.SetRotationDirection(RotationDirection.Right);
        }

        private void FaceTarget()
        {
            if (_Target == null)
                return;

            var directionToTarget = (_Target.position - transform.position).normalized;
            var angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

        protected override void DisableBehaviour()
        {
            _move.SetMovementInput(false);
            _rotate.SetRotationDirection(0f);
            this.enabled = false;
        }
    }
}
