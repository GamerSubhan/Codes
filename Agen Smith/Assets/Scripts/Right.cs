using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Right : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    public GameObject car;

    void Update(){
        if (isPressed){
            car.transform.Translate(0, 0.4f, 0);
        }
    }

    public void OnPointerDown(PointerEventData eventData){
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData){
        isPressed = false;
    }
}
