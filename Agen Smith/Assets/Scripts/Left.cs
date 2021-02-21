using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Left : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject car;
    private bool isPressed = false;

    void Update()
    {
        if (isPressed){
            car.transform.Translate(0, -0.4f, 0);
        }
    }

    public void OnPointerDown(PointerEventData eventData){
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData){
        isPressed = false;
    }
}
