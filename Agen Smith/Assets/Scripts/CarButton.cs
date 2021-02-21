using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarButton : MonoBehaviour
{
    private float speed = 4f;
    public GameObject car;

    public void RightButton(){
        car.transform.Translate(Vector2.down * speed);
    }

    public void LeftButton(){
        car.transform.Translate(Vector2.up * speed);
    }
}
