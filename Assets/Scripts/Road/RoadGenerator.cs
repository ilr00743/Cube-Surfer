using UnityEngine;
using Random = UnityEngine.Random;

namespace Road
{
    public class RoadGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject[] _chunks;
        [SerializeField] private GameObject _finish;
        [SerializeField] private int _chunksAmount;

        private void Start()
        {
            Generate();
        }

        private void Generate()
        {
            var position = new Vector3(0, 0, 0);
            var offsetZ = 30;
        
            for (int i = 0; i < _chunksAmount; i++)
            {
                var chunk = Instantiate(_chunks[Random.Range(0, _chunks.Length)]);
                chunk.transform.position = position;
                position.z += offsetZ;
            }

            Instantiate(_finish, position, Quaternion.identity);
        }
    }
}