using System.Collections;
using UnityEngine;

namespace Cubes
{
    public class TrailColorMixer : MonoBehaviour
    {
        [SerializeField] private CubesContainer _cubesContainer;
        [SerializeField] private float _changingColorDuration;
        private TrailRenderer _trail;
        private Color _startColor;
        private Color _endColor;

        private void Awake()
        {
            _trail = GetComponent<TrailRenderer>();
        }

        private void OnEnable()
        {
            _cubesContainer.Transformed += OnChangeColor;
        }

        private void OnDisable()
        {
            _cubesContainer.Transformed += OnChangeColor;
        }

        private void Start()
        {
            _startColor = _cubesContainer.GetLastCubeColor();
            _endColor = _cubesContainer.GetLastCubeColor();
            _trail.startColor = _startColor;
            _trail.endColor = _endColor;
        }

        private void OnChangeColor()
        {
            StopCoroutine(nameof(OnChangeColorForSeconds));
            StartCoroutine(OnChangeColorForSeconds(_changingColorDuration));
        }
    
        private IEnumerator OnChangeColorForSeconds(float duration)
        {
            float time = 0;
            var previousStartColor = _trail.startColor;
            var previousEndColor = _trail.endColor;
            var targetColor = _cubesContainer.GetLastCubeColor();
        
            while (time < duration)
            {
                _trail.startColor = Color.Lerp(previousStartColor, targetColor, time /duration);
                _trail.endColor = Color.Lerp(previousEndColor, previousStartColor, time/duration);
                time += Time.deltaTime;
                yield return null;
            }
        }
    }
}