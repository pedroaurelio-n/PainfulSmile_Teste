using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PedroAurelio.PainfulSmile
{
    public class PlayerWeaponHandler : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private List<ShootBullets> normalShots;
        [SerializeField] private List<ShootBullets> specialShots;

        public void FireNormalShot(InputAction.CallbackContext ctx)
        {
            switch (ctx.phase)
            {
                case InputActionPhase.Performed:
                    SetAllShotsActive(normalShots, true);
                    SetAllShotsActive(specialShots, false);
                    break;

                case InputActionPhase.Canceled:
                    SetAllShotsActive(normalShots, false);
                    break;
            }
        }

        public void FireSpecialShot(InputAction.CallbackContext ctx)
        {
            switch (ctx.phase)
            {
                case InputActionPhase.Performed:
                    SetAllShotsActive(specialShots, true);
                    SetAllShotsActive(normalShots, false);
                    break;

                case InputActionPhase.Canceled:
                    SetAllShotsActive(specialShots, false);
                    break;
            }
        }

        public void DisableAllShots()
        {
            SetAllShotsActive(normalShots, false);
            SetAllShotsActive(specialShots, false);
        }

        private void SetAllShotsActive(List<ShootBullets> list, bool value)
        {
            if (list.Count == 1)
            {
                list[0].SetShootInput(value);
                return;
            }

            foreach (ShootBullets shoot in list)
                shoot.SetShootInput(value);
        }
    }
}
