using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class BrakeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event Action onPointerDown;


    public void OnPointerDown(PointerEventData eventData)
    {
        onPointerDown?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onPointerDown?.Invoke();
    }
}
