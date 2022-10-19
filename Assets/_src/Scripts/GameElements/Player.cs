using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    public class Player : MonoBehaviour, IKillable
    {
        public delegate void PlayerDeath();
        public static event PlayerDeath onPlayerDeath;

        public void Die()
        {
            onPlayerDeath?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
