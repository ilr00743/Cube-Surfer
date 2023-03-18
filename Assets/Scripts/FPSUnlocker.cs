using UnityEngine;

public class FPSUnlocker : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 120;
    }
}