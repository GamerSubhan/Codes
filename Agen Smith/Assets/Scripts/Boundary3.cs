using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary3 : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10f, 10f),
        Mathf.Clamp(transform.position.y, -4f, 4f), transform.position.z);
    }
}
