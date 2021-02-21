using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary5 : MonoBehaviour
{
   void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -13f, 19f),
        Mathf.Clamp(transform.position.y, -7f, 10f), transform.position.z);
    }
}
