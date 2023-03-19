using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LevelLoader : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadSceneAsync("Level");
        }
    }
}
