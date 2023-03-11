using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CubesContainer : MonoBehaviour
{
    [SerializeField] private List<Cube> _cubes = new List<Cube>();
    [SerializeField] private int _removedCubesCount;
    [SerializeField] private Transform _parent;

    public int RemovedCubesCount => _removedCubesCount;

    public void Add(Cube cube)
    {
        cube.transform.SetParent(_parent);
        _cubes.Add(cube);
        ShiftCubesUp();
    }

    public void Remove(Cube cube)
    {
        cube.transform.SetParent(null);
        _cubes.Remove(cube);
        _removedCubesCount++;
        StartCoroutine(ShiftCubesDown());
    }

    private void ShiftCubesUp()
    {
        _parent.transform.localPosition += Vector3.up;
    }
    
    private IEnumerator ShiftCubesDown()
    {
        yield return new WaitForSeconds(0.5f);
        _parent.transform.DOLocalMoveY(_parent.transform.localPosition.y - RemovedCubesCount, 0.3f);
    }

    public Vector3 GetLastCubePosition()
    {
        return _cubes[^1].transform.localPosition;
    }

    public void ResetRemovedCubesCount()
    {
        _removedCubesCount = 0;
    }
}
