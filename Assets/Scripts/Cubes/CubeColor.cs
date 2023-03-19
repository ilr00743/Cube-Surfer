using UnityEngine;

namespace Cubes
{
    [CreateAssetMenu(fileName = "CubeColor", menuName = "Cube/Color", order = 0)]
    public class CubeColor : ScriptableObject
    {
        [SerializeField] private Color[] _colors;

        public Color GetRandomColor()
        {
            var randomIndex = Random.Range(0, _colors.Length);
            return _colors[randomIndex];
        }
    }
}