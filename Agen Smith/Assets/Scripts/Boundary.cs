using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -11f, 11f),
        Mathf.Clamp(transform.position.y, -4f, 4f), transform.position.z);
    }
}
