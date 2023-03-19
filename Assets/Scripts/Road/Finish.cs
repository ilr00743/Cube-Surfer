using Cubes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Road
{
    public class Finish : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Cube cube))
            {
                cube.GetComponentInParent<Movement>().CanMove = false;
                Debug.Log(cube.GetComponentInParent<CubesContainer>().CubesAmount + " cubes left");
                Invoke(nameof(RestartLevel), 2f);
            }
        }

        private void RestartLevel()
        {
            SceneManager.LoadSceneAsync("LoadScene");
        }
    }
}