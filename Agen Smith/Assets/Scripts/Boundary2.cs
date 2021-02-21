using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary2 : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -16f, 25f),
        Mathf.Clamp(transform.position.y, -10f, 10f), transform.position.z);
    }
}
