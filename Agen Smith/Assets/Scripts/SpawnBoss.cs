using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject BossMonster;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnDelay;

    bool isSpawn = false;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnTime, spawnDelay);
    }

    void SpawnEnemy(){
        Vector2 pos = new Vector2(5f, 0f);

        Instantiate(BossMonster, pos, Quaternion.identity);
        
        if(isSpawn){
            CancelInvoke("SpawnEnemy");
        }
    }
}
