using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    [RequireComponent(typeof(Enemy))]
    public class ShootFrontwards : BaseBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float minDistanceToShoot;

        private ShootBullets _shoot;
        
        private void OnValidate()
        {
            if (minDistanceToShoot < 0f)
                minDistanceToShoot = 0f;
        }

        private void Awake() => _shoot = GetComponentInChildren<ShootBullets>();

        protected override void OnEnable()
        {
            base.OnEnable();

            if (minDistanceToShoot == 0f)
                _shoot.SetShootInput(true);
            else
                _shoot.SetShootInput(false);
        }

        private void Update() => CheckForShotDistance();

        private void CheckForShotDistance()
        {
            if (minDistanceToShoot == 0f)
                return;

            var distanceToTarget = Vector2.Distance(_Target.position, transform.position);

            if (distanceToTarget <= minDistanceToShoot)
                _shoot.SetShootInput(true);
            else
                _shoot.SetShootInput(false);
        }

        protected override void DisableBehaviour()
        {
            _shoot.SetShootInput(false);
            this.enabled = false;
        }
    }
}
