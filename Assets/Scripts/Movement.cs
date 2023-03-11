using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    
    private void FixedUpdate()
    {
        _transform.localPosition += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * 5.0f *Time.deltaTime;
    }
}