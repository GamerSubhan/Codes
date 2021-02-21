using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time7 : MonoBehaviour
{
    public Text TimerText;
    private float startingTime;
    [SerializeField] private GameObject Win, VictoryMus, Music;
    [SerializeField] private GameObject Message;
    public GameObject button1, button2;

    bool timeOver;
    void Start()
    {
        Message.SetActive(true);
        Win.SetActive(false);
        startingTime = Time.time;
        Time.timeScale = 0f;

    }

    void Update()
    {
        float t = Time.time - startingTime;
        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f1");

        TimerText.text = minutes + ":" + seconds;

        Destroy(button1, 110f);
        Destroy(button2, 110f);

    }
}
