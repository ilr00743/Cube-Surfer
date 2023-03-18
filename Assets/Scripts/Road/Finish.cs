using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Cube cube))
        {
            cube.GetComponentInParent<Movement>().CanMove = false;
            Debug.Log(cube.GetComponentInParent<CubesContainer>().CubesAmount);
        }
    }
}
