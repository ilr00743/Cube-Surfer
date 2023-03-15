using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Cube: MonoBehaviour
{
    [SerializeField] private CubeColor _cubeColor;
    [SerializeField] private bool _isStacked;
    private MeshRenderer _renderer;
    private CubesContainer _cubesContainer;
    public Color Color => _renderer.material.color;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _renderer.material.color = _cubeColor.GetRandomColor();
        _cubesContainer = FindObjectOfType<CubesContainer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        StackCube(collision);
        UnstackCube(collision);
    }

    private void StackCube(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube cube))
        {
            if (cube._isStacked == false)
            {
                _cubesContainer.Add(cube);
                cube._isStacked = true;
            }
        }
    }

    private void UnstackCube(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle) && _isStacked)
        {
            _cubesContainer.Remove(this);
            _isStacked = false;
        }
    }
}