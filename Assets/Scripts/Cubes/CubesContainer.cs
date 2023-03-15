using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEngine;

public class CubesContainer : MonoBehaviour
{
    [SerializeField] private List<Cube> _cubes = new();
    [SerializeField] private Transform _parent;
    public event Action Transformed;
    
    public void Add(Cube cube)
    {
        ShiftCubesUp();
        PlacingNewCube(cube);
        _cubes.Add(cube);
        Transformed?.Invoke();
    }

    private void PlacingNewCube(Cube cube)
    {
        cube.transform.SetParent(_parent);
        var position = GetLastCubePosition();
        cube.transform.localPosition = position + Vector3.down;
    }

    public void Remove(Cube cube)
    {
        cube.transform.SetParent(null);
        _cubes.Remove(cube);
        StartCoroutine(ShiftCubesDown());
        Transformed?.Invoke();
    }

    private void ShiftCubesUp()
    {
        foreach (var cube in _cubes)
        {
            cube.transform.localPosition += Vector3.up;  
        }
    }
    
    private IEnumerator ShiftCubesDown()
    {
        yield return new WaitForSeconds(0.35f);
        foreach (var cube in _cubes)
        {
            cube.transform.localPosition += Vector3.down;
        }
    }

    private Vector3 GetLastCubePosition()
    {
        return _cubes[^1].transform.localPosition;
    }

    public Color GetLastCubeColor()
    {
        return _cubes[^1].Color;
    }
}