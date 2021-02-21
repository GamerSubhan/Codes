using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public  GameObject key;
    public float spawnTime;
    public float spawnDelay;
    bool canSpawn = false;
    public Transform keyPos;

    void Start()
    {
        InvokeRepeating("KeySpawn", spawnTime, spawnDelay);
    }

    void KeySpawn(){
        Vector3 pos = keyPos.position;
        Instantiate(key, pos, Quaternion.identity); 
        if (canSpawn){
            CancelInvoke("KeySpawn");
        }
    }

    
}
