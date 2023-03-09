using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesContainer : MonoBehaviour
{
    [SerializeField] private List<Cube> _cubes = new List<Cube>();

    private void FixedUpdate()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * 4.0f *Time.deltaTime;
    }

    public void Add(Cube cube)
    {
        ShiftCubes();
        _cubes.Add(cube);
        cube.transform.SetParent(transform);
    }

    private void ShiftCubes()
    {
        foreach (var cube in _cubes)
        {
            cube.transform.localPosition += Vector3.up * 1.07f;
        }
    }
}
