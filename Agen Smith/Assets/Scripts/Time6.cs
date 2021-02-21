using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time6 : MonoBehaviour
{
    public Text TimerText;
    private float startingTime;
    [SerializeField] private GameObject Win, VictoryMus, Music;
    public GameObject littleAlien, FlyingMon, GreenMon;
    public float spawnTime;
    public float spawnDelay;
    public Transform colliderPoint;
    public float colliderRange;
    public LayerMask gearLayer;
    public GameObject Welcome;
    public GameObject Enemy, healthItem;
    public float spawnTime2, spawnTime3;
    public float spawnDelay2, spawnDelay3;
    


    bool stopSpawning = false;
    void Start()
    {
        Win.SetActive(false);
        startingTime = Time.time;

        Destroy(Welcome, 4f);

        InvokeRepeating("SpawnLittle", spawnTime, spawnDelay);
        InvokeRepeating("SpawningObjectsH", spawnTime2, spawnDelay2);
        InvokeRepeating("SpawningObjectsE", spawnTime3, spawnDelay3);
    }

    void Update()
    {
        float t = Time.time - startingTime;
        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f1");

        TimerText.text = minutes + ":" + seconds;
        
        if (minutes == "2"){
            Destroy(littleAlien);
            Destroy(FlyingMon);
            Destroy(GreenMon);
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

     void SpawningObjectsE(){
        Vector2 position = new Vector2(Random.Range(-8f, 8f),Random.Range(-2f, 2f));
        Instantiate(Enemy, position, Quaternion.identity);

        if(stopSpawning){
            CancelInvoke("SpawningObjectsE");
        }
    }

    void SpawningObjectsH(){
        Vector2 position2 = new Vector2(Random.Range(-7f, 7f),Random.Range(-5f, 5f));
        Instantiate(healthItem, position2, Quaternion.identity);

        if(stopSpawning){
            CancelInvoke("SpawningObjectsH");
        }
    }

    
}
