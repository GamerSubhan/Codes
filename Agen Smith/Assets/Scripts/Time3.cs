using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time3 : MonoBehaviour
{
    public Text TimerText;
    private float startingTime;
    [SerializeField] private GameObject Win, VictoryMus, Music;
    [SerializeField] private GameObject Message, Message2;
    public GameObject Enemy;
    public GameObject Enemy2;
    public GameObject Welcome;
    public GameObject Text1;
    public GameObject Text;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    public GameObject Fade;
    public Animator _anim;
    public Transform colliderPoint;
    public float colliderRange;
    public LayerMask carLayer;
    private string minutes, seconds;
    public Collider2D collider;
    public float spawnTime;
    public float spawnDelay;
    public GameObject Mar;
    [SerializeField] private float keysOfCar;

    bool SpawnMarket = false;

    void Start()
    {
        Win.SetActive(false);
        startingTime = Time.time;
        _anim = GetComponent<Animator>();

        InvokeRepeating("SpawnBuilding", spawnTime, spawnDelay);
    }

    void Update()
    {
        float t = Time.time - startingTime;
        minutes = ((int) t / 60).ToString();
        seconds = (t % 60).ToString("f1");

        TimerText.text = minutes + ":" + seconds;

        if (minutes == "1" && seconds == "40.0"){
            Message2.SetActive(true);
            Destroy(Message2, 4f);
            Destroy(Enemy, 0.01f);
            Destroy(Enemy2, 0.01f);
        }


        if (seconds == "1.0"){
            Text1.SetActive(true);
            Destroy(Text1, 4f);
            Welcome.SetActive(true);
        }

        if (seconds == "6.0"){
            Text.SetActive(true);
            Destroy(Text, 3f);
            Welcome.SetActive(false);
        }

        if (seconds == "40.0"){
            Text2.SetActive(true);
            Destroy(Text2, 3f);
        }

        if (minutes == "1"){
            Text3.SetActive(true);
            Destroy(Text3, 3f);
        }

        if (minutes == "1" && seconds == "36.0"){
            Destroy(Enemy);
            Destroy(Enemy2);
            Text4.SetActive(true);
        }
        
        Collider2D[] collider = Physics2D.OverlapCircleAll(colliderPoint.position, colliderRange, carLayer);
        foreach(Collider2D player in collider){
            Debug.Log("In Car");

            if(keysOfCar >= 1 && Input.GetKeyDown(KeyCode.F)){
                Win.SetActive(true);
                Music.SetActive(false);
                VictoryMus.SetActive(true);
                Time.timeScale = 0f;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collider){
         
         if (collider.tag == "market"){
                Fade.SetActive(true);
                _anim.SetTrigger("Fade");
                Destroy(Fade, 1.2f);
                keysOfCar++;
            }
    }

    void OnColliderEnter2D(Collider2D col){
        if (col.tag == "car"){
            Debug.Log("InCar!");
            if(keysOfCar >= 1){
                Win.SetActive(true);
                Music.SetActive(false);
                VictoryMus.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    void SpawnBuilding(){
        Vector3 pos = new Vector3(-9, -2, transform.position.z);
        Instantiate(Mar, pos, Quaternion.identity);
        
        if (SpawnMarket){
            CancelInvoke("SpawnBuilding");
        }   
        
    }

    
}
