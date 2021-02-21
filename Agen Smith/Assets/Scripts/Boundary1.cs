﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary1 : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -11f, 11f),
        Mathf.Clamp(transform.position.y, -4f, 3f), transform.position.z);
    }
}