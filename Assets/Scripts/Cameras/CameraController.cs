using UnityEngine;

namespace Cameras
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private float _followSpeed;
        private Vector3 _offset;

        private void Start()
        {
            _offset = transform.position - _target.transform.position;
        }

        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(_target.transform.position.x, _target.transform.position.y, _target.transform.position.z) + _offset,
                _followSpeed * Time.deltaTime);
        }
    }
}