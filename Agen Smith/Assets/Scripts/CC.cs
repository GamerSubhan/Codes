using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CC : MonoBehaviour
{
    private int crystal;
    public Text text;

    public void Col(){
        crystal++;
        text.text = ": " + crystal.ToString();
        Destroy(gameObject);
    }
    
}
