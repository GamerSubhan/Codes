using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser2 : MonoBehaviour
{
    public Transform colliderPoint;
    public float range;
    public LayerMask AntiLayer;
    void Start()
    {
        
    }

    void Update()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(colliderPoint.position, range, AntiLayer);
        foreach(Collider2D laser in col){
            laser.GetComponent<AntiCh>().TakeDamage(.1f);
        }
    }
}
