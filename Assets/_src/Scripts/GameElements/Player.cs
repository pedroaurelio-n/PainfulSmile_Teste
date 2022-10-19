using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    public class Player : MonoBehaviour, IKillable
    {
        public void Die()
        {
            gameObject.SetActive(false);
        }
    }
}
