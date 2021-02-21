using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    void Update(){

    }
    
    public void GainHealth(){
        Debug.Log("Health!");
        Destroy(gameObject);
    }
}
