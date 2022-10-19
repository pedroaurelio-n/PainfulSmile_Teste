using UnityEngine;
using UnityEngine.SceneManagement;

namespace PedroAurelio.PainfulSmile
{
    public class ChangeScene : MonoBehaviour
    {
        public void ChangeSceneByName(string sceneName) => SceneManager.LoadScene(sceneName);
    }
}
