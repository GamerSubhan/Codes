using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public bool IsSpawning = false;
    public GameObject Player;
    public Transform ManagerPos;
    void Start()
    {
        
    }

    void Update()
    {
        if (IsSpawning){
            IsSpawning = true;
            Instantiate(Player, ManagerPos.position, Quaternion.identity);
        }
    }
}
