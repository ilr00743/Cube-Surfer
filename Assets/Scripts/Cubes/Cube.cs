using Money;
using Road;
using UnityEngine;

namespace Cubes
{
    public class Cube: MonoBehaviour
    {
        [SerializeField] private CubeColor _cubeColor;
        [SerializeField] private bool _isStacked;
        private MeshRenderer _renderer;
        private CubesContainer _cubesContainer;
        private CoinCollector _coinCollector;
        public Color Color => _renderer.material.color;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            _renderer.material.color = _cubeColor.GetRandomColor();
            _cubesContainer = FindObjectOfType<CubesContainer>();
        }

        private void OnEnable()
        {
            _coinCollector = GetComponent<CoinCollector>();
        }

        public void SetParent(Transform parent)
        {
            transform.parent = parent;
        }
    
        private void OnTriggerEnter(Collider collision)
        {
            StackCube(collision);
            UnstackCube(collision);
            TakeCoin(collision);
        }

        private void StackCube(Collider collision)
        {
            if (collision.TryGetComponent(out Cube cube))
            {
                if (cube._isStacked == false)
                {
                    _cubesContainer.Add(cube);
                    cube._isStacked = true;
                }
            }
        }

        private void UnstackCube(Collider collision)
        {
            if (collision.TryGetComponent(out Obstacle obstacle) && _isStacked)
            {
                _cubesContainer.Remove(this);
                _isStacked = false;
            }
        }

        private void TakeCoin(Collider collision)
        {
            if (collision.TryGetComponent(out Coin coin))
            {
                _coinCollector.Collect();
                Destroy(coin.gameObject);
            }
        }
    }
}