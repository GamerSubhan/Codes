using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    private float startingTime;

    void FixedUpdate(){

    transform.position = new Vector3(Target.position.x, Target.position.y, transform.position.z);
    
    }
}
