using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary7 : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6f, 4f),
        Mathf.Clamp(transform.position.y, -1f, 7f), transform.position.z);
    }
}
