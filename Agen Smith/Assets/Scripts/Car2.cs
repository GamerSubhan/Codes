using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform target;
    private float speedX = 4f;
    private float speedY = 30f;
    [SerializeField] GameObject Fade, vehicle, Player;
    public GameObject obs;
    public Animator animator;
    public float spawnTime, spawnDelay;
    public Transform ColliderPoint;
    public float colliderRange;
    public LayerMask obstacleLayer;
    private float currentHealth; 
    public float maxHealth = 12f;
    public GameObject Lose, Message, Welcome, Camera, Camera1;
    public GameObject Car;
    

    bool IsSpawning = false; 
    void Start()
    {
        currentHealth = maxHealth;

        Destroy(Message, 4f);
        Destroy(Welcome, 3f);
        
        animator = GetComponent<Animator>();

        InvokeRepeating("SpawnObstacle", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4f, 4f),
        Mathf.Clamp(transform.position.y, 22f, 2228f), transform.position.z);

        Collider2D[] array = Physics2D.OverlapCircleAll(ColliderPoint.position, colliderRange, obstacleLayer);
        foreach(Collider2D obect in array){
            currentHealth -= 4f;
            
            if (currentHealth <= 0){
                Time.timeScale = 0f;
                Lose.SetActive(true);
                Destroy(this.gameObject);
            }
        }
    }

    void Movement(){
       float InputX = Input.GetAxis("Horizontal");
       float InputY = Input.GetAxis("Vertical");

       rb.position = Vector3.MoveTowards(transform.position, target.position, speedY * Time.deltaTime);
       rb.velocity = new Vector2(InputX * speedX, 0);
       
    }

    void OnTriggerEnter2D(Collider2D collider){
       if (collider.tag == "Target")
       {
           Debug.Log("ARRIVE!");
           
           vehicle.SetActive(false);
           Player.SetActive(true);
           Destroy(Car);
           Camera.SetActive(false);
           Camera1.SetActive(true);
       }
   }

   void SpawnObstacle(){
       if (IsSpawning){
           CancelInvoke("SpawnObstacle");
       }

       Vector2 position = new Vector2(Random.Range(-4f, 4f), Random.Range(0, -2210));
       Instantiate(obs, position, Quaternion.identity);
   }


}
