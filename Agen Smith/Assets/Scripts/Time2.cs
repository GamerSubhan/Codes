using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time2 : MonoBehaviour
{
    public Text TimerText;
    private float startingTime;
    [SerializeField] private GameObject Win, VictoryMus, Music;
    [SerializeField] private GameObject Message;
    public GameObject Enemy;
    public GameObject Enemy2;
    public Transform colliderPoint;
    public float range;
    public LayerMask gearLayer;
    public Transform colliderPoint2;
    public float range2;
    public LayerMask doorLayer;
    private float key;

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

        if (minutes == "1" && seconds == "40.0"){
            Message.SetActive(true);
            Destroy(Enemy);
            Destroy(Enemy2);
        }

        Collider2D[] collider = Physics2D.OverlapCircleAll(colliderPoint.position, range, gearLayer);
        Collider2D[] collider2 = Physics2D.OverlapCircleAll(colliderPoint2.position, range2, doorLayer);
        
        foreach(Collider2D key in collider){
            Destroy(key.gameObject);
            Win.SetActive(true);
            VictoryMus.SetActive(true);
            Time.timeScale = 0f;
            Music.SetActive(false);
        }

    }

    
}
