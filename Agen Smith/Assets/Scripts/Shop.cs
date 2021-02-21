using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public int Money = 200;
    public Text moneyText;
    public Text inventory;

    public void AddItem(string item){
        moneyText.text = Money.ToString();
        inventory.text = "\n" + item;
    }

}
