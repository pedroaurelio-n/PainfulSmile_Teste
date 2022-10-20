using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    public abstract class BaseBehaviour : MonoBehaviour
    {
        [SerializeField] protected Transform _Target;

        protected virtual void Start()
        {
            if (_Target == null)
                _Target = GetComponent<Enemy>().Target;
        }
        
        protected abstract void DisableBehaviour();

        protected virtual void OnEnable()
        {
            Player.onPlayerDeath += DisableBehaviour;
            ShowGameTime.onEndSession += DisableBehaviour;
        }

        protected void OnDisable()
        {
            Player.onPlayerDeath -= DisableBehaviour;
            ShowGameTime.onEndSession -= DisableBehaviour;
        }
    }
}
