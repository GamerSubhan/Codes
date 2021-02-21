using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time5 : MonoBehaviour
{
    public Text TimerText;
    private float startingTime;
    [SerializeField] private GameObject Win, VictoryMus, Music;
    public GameObject littleAlien;
    public float spawnTime;
    public float spawnDelay;
    public GameObject Message;
    public GameObject MessageEnd;
    public Transform colliderPoint;
    public float colliderRange;
    public LayerMask gearLayer;
    public GameObject Welcome;

    bool stopSpawning = false;
    void Start()
    {
        Win.SetActive(false);
        startingTime = Time.time;

        Destroy(Welcome, 4f);

        InvokeRepeating("SpawnLittle", spawnTime, spawnDelay);

    }

    void Update()
    {
        float t = Time.time - startingTime;
        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f1");

        TimerText.text = minutes + ":" + seconds;

        if (seconds == "1.0"){
            Message.SetActive(true);
            Destroy(Message, 3f);
        }

        
        if (minutes == "2"){
            MessageEnd.SetActive(true);
            Destroy(littleAlien);
        }

        Collider2D[] collider = Physics2D.OverlapCircleAll(colliderPoint.position, colliderRange, gearLayer);
        foreach(Collider2D key in collider){
            Destroy(key.gameObject);
            Win.SetActive(true);
            VictoryMus.SetActive(true);
            Time.timeScale = 0f;
            Music.SetActive(false);
        }
    }

    void SpawnLittle(){
        Vector2 pos = new Vector2(Random.Range(-15f, 18f), Random.Range(-6f, 6f));
        Instantiate(littleAlien, pos, Quaternion.identity);

        if (stopSpawning){
            CancelInvoke("SpawnLittle");
        }
    }

}
