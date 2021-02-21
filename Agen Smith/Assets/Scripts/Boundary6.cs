using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary6 : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7f, 11f),
        Mathf.Clamp(transform.position.y, -7f, 7f), transform.position.z);
    }
}
