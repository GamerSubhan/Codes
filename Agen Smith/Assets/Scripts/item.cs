using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public int cost;
    public string itemName;

    public void Bought(){
        if (GetComponentInParent<Shop>().Money >= cost){
            GetComponentInParent<Shop>().Money -= cost;
            GetComponentInParent<Shop>().AddItem(itemName);
        }
    }
}
