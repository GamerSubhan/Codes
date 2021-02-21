using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Spawn : MonoBehaviour
{
    public GameObject FlyinMonster;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnDelay;

    bool isSpawn = false;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnTime, spawnDelay);
    }

    void Update()
    {
        
    }

    void SpawnEnemy(){
        Vector2 pos = new Vector2(Random.Range(-8f, 8f), Random.Range(-3f , 3f));

        Instantiate(FlyinMonster, pos, Quaternion.identity);
        
        if(isSpawn){
            CancelInvoke("SpawnEnemy");
        }
    }
}
