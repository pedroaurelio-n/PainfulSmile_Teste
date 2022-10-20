using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Collider2D))]
    public class Player : MonoBehaviour, IKillable
    {
        public delegate void PlayerDeath();
        public static event PlayerDeath onPlayerDeath;

        public void Die()
        {
            onPlayerDeath?.Invoke();
            gameObject.SetActive(false);
        }

        private void DisablePlayerCollisionAndInput()
        {
            GetComponent<PlayerInput>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }

        private void OnEnable() => ShowGameTime.onEndSession += DisablePlayerCollisionAndInput;
        private void OnDisable() => ShowGameTime.onEndSession -= DisablePlayerCollisionAndInput;
    }
}
