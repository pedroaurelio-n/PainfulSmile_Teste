using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    public class ShootFrontwards : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Transform target;
        [SerializeField] private float minDistanceToShoot;

        private ShootBullets _shoot;
        
        private void OnValidate()
        {
            if (minDistanceToShoot < 0f)
                minDistanceToShoot = 0f;
        }

        private void Awake()
        {
            _shoot = GetComponentInChildren<ShootBullets>();
        }

        private void OnEnable()
        {
            if (target == null || minDistanceToShoot == 0f)
                _shoot.SetShootInput(true);
            else
                _shoot.SetShootInput(false);
        }

        private void Update()
        {
            CheckForShotDistance();
        }

        private void CheckForShotDistance()
        {
            if (target == null || minDistanceToShoot == 0f)
                return;

            var distanceToTarget = Vector2.Distance(target.position, transform.position);

            if (distanceToTarget <= minDistanceToShoot)
                _shoot.SetShootInput(true);
            else
                _shoot.SetShootInput(false);
        }
    }
}
