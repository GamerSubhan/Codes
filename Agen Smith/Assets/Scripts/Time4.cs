using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time4 : MonoBehaviour
{
    public Text TimerText;
    private float startingTime;
    [SerializeField] private GameObject Win, VictoryMus, Music;
    [SerializeField] private GameObject  Text, Text1, Text2, Text3;

    bool timeOver;
    void Start()
    {
        Win.SetActive(false);
        startingTime = Time.time;

        


    }

    void Update()
    {
        float t = Time.time - startingTime;
        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f1");

        TimerText.text = minutes + ":" + seconds;

        if (seconds == "2.0"){
            Text.SetActive(true);
            Destroy(Text, 5f);
        }

        if (seconds == "7.0"){
            Text1.SetActive(true);
            Destroy(Text1, 6f);
        }

        if (seconds == "13.0"){
            Text2.SetActive(true);
            Destroy(Text2, 5f);
        }

        if (seconds == "18.0"){
            Text3.SetActive(true);
            Destroy(Text3, 4f);
        }
        
        if (minutes == "2"){
            Time.timeScale = 0f;
            Win.SetActive(true);
            VictoryMus.SetActive(true);
            Music.SetActive(false);
        }
    }
    

}