using System;
using UnityEngine;

public class Cube: MonoBehaviour
{
    [SerializeField] private bool isStacked;
    [SerializeField] private CubeColor _cubeColor;
    private MeshRenderer _renderer;
    private CubesContainer _cubesContainer;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _cubesContainer = FindObjectOfType<CubesContainer>();
    }

    private void Start()
    {
        _renderer.material.color = _cubeColor.GetRandomColor();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Cube cube))
        {
            if (cube.isStacked == false)
            {
                var position = _cubesContainer.GetLastCubePosition();
                _cubesContainer.Add(cube);
                cube.transform.localPosition = position - Vector3.up;
                cube.isStacked = true;
            }
        }
        
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle) && isStacked)
        {
            isStacked = false;
            _cubesContainer.Remove(this);
        }

        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            _cubesContainer.ResetRemovedCubesCount();
        }
    }
}