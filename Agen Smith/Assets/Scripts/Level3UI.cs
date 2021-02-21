using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3UI : MonoBehaviour
{
    public GameObject Text;
    

    void Update(){
        Destroy(Text, 4f);
    } 
}
