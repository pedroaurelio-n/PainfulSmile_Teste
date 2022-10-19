using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    [RequireComponent(typeof(Move))]
    [RequireComponent(typeof(Rotate))]
    public class FollowTarget : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Transform target;
        [SerializeField] private float minDistanceFromTarget;
        [SerializeField, Range(0f, 1f)] private float rotationThreshold = 0.1f;

        private Move _move;
        private Rotate _rotate;

        private void OnValidate()
        {
            if (minDistanceFromTarget < 0f)
                minDistanceFromTarget = 0f;
        }

        private void Awake()
        {
            _move = GetComponent<Move>();
            _rotate = GetComponent<Rotate>();

            if (minDistanceFromTarget == 0f)
                _move.SetMovementInput(true);
        }

        private void Update()
        {
            CheckTargetDistance();
            RotateTowardsTarget();
        }

        private void CheckTargetDistance()
        {
            if (target == null && minDistanceFromTarget == 0f)
                return;
            
            var distanceToTarget = Vector2.Distance(target.position, transform.position);

            if (distanceToTarget > minDistanceFromTarget)
                _move.SetMovementInput(true);
            else
                _move.SetMovementInput(false);
        }

        private void RotateTowardsTarget()
        {
            if (target == null)
                return;
            
            var directionToTarget = target.position - transform.position;
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
    }
}
