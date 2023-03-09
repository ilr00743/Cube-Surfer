using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube: MonoBehaviour
{
    [SerializeField] private Color _targetColor;
    [SerializeField] private bool isStacked;
    private Color _startColor;
    private MeshRenderer _renderer;
    private CubesContainer _cubesContainer;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _cubesContainer = FindObjectOfType<CubesContainer>();
    }

    private void Start()
    {
        //TODO: Generate random color for cube
        _startColor = _renderer.material.color;
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        while (true)
        {
            var r = Mathf.Lerp(_startColor.r, _targetColor.r, Time.time * 0.2f);
            var g = Mathf.Lerp(_startColor.g, _targetColor.g, Time.time* 0.2f);
            var b = Mathf.Lerp(_startColor.b, _targetColor.b, Time.time* 0.2f);
            
            _renderer.material.color = new Color(r, g, b);
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Cube cube))
        {
            if (cube.isStacked == false)
            {
                cube.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                _cubesContainer.Add(cube);
                cube.isStacked = true;
                Debug.Log($"{collision.collider.name}");    
            }
        }
    }
}
