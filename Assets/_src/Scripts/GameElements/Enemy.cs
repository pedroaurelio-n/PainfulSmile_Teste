using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    public class Enemy : MonoBehaviour, IKillable
    {
        public void Die()
        {
            gameObject.SetActive(false);
        }
    }
}
