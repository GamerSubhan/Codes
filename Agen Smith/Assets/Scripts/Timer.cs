using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float startingTime;
    [SerializeField] private GameObject Win, VictoryMus, Music;



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

        if (minutes == "2"){
            Time.timeScale = 0f;
            Win.SetActive(true);
            VictoryMus.SetActive(true);
            Music.SetActive(false);
        }


    }
    

}
