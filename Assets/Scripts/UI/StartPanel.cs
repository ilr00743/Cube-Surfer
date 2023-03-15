using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartPanel : MonoBehaviour, IPointerClickHandler
{
    public event Action Tapped;
    public void OnPointerClick(PointerEventData eventData)
    {
        Tapped?.Invoke();
        gameObject.SetActive(false);
    }
}
