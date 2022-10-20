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

        private void Awake()
        {
            _shoot = GetComponentInChildren<ShootBullets>();
            if (_shoot == null)
                Debug.LogError($"Enemy doesn't have a child with ShootBullets component.");
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            if (minDistanceToShoot == 0f)
                _shoot.SetShootInput(true);
        }

        private void Update() => CheckForShotDistance();

        private void CheckForShotDistance()
        {
            if (minDistanceToShoot == 0f || _Target == null)
                return;

            var distanceToTarget = Vector2.Distance(_Target.position, transform.position);

            var willShoot = distanceToTarget <= minDistanceToShoot ? true : false;
            _shoot.SetShootInput(willShoot);
        }

        protected override void DisableBehaviour()
        {
            _shoot.SetShootInput(false);
            this.enabled = false;
        }
    }
}
