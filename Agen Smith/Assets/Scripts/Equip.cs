using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    private GameObject shopItemPrefab;
    public GameObject Bullet;
    private Player player;

    void Update(){
        player._laser = Bullet;
    }
}
