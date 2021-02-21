using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    private float speed = 3f;
    [SerializeField] float currentHealth;
    [SerializeField] float maxHealth = 100f;
    public SpriteRenderer _sprite;
    [SerializeField] private Animator _anim;
    float InputX;
    float InputY;
    public GameObject _laser;
    [SerializeField] private GameObject Enemy;
    public int crystal;
    [SerializeField] private Text text;
    public float spawnTime;
    public float spawnDelay;
    public float spawnTime2;
    public float spawnDelay2;
    public float spawnTime3;
    public float spawnDelay3;
    public bool stopSpawning = false;
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject healthItem;
    public Transform ColliderPoint;
    public float colliderRange;
    public LayerMask crystalLayer;
    public Transform HpPoint;
    public float rangePoint;
    public LayerMask HpLayer;
    public GameObject Lose;
    public AudioSource audio,audioHealth, collectSound;
    public GameObject DefeatMus, Music;
    public GameObject Resume;

    public HealthBar healthBar;


    

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        audio.Stop();
        audioHealth.Stop();
        collectSound.Stop();

        Time.timeScale = 0f;

        rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        text = GetComponent<Text>();
        audio = GetComponent<AudioSource>();

        InvokeRepeating("SpawningObjectsE", spawnTime, spawnDelay);
        InvokeRepeating("SpawningObjectsI", spawnTime2, spawnDelay2);
        InvokeRepeating("SpawningObjectsH", spawnTime3, spawnDelay3);
        
    }

    void Update()
    {
        
        Movement();

        Collider2D[] collider = Physics2D.OverlapCircleAll(HpPoint.position, rangePoint, HpLayer);
        foreach(Collider2D health in collider){
            health.GetComponent<Health>().GainHealth();
            currentHealth = maxHealth;
            audioHealth.Play();
        }

        Collider2D[] cr = Physics2D.OverlapCircleAll(ColliderPoint.position, colliderRange, crystalLayer);
        foreach(Collider2D player in cr){
            player.GetComponent<CC>().Col();
            crystal++;
            text.text = ": " + crystal.ToString();
            collectSound.Play();
        }


    }

    
    void GizmosDraw(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(HpPoint.position, rangePoint);
    }


    void Movement(){
        
        InputX =  Input.GetAxis("Horizontal");
        InputY =   Input.GetAxis("Vertical");

        

        if (InputX > 0){
            _sprite.flipX = false;
        }

        else if (InputX < 0){
            _sprite.flipX = true;
            
        }


        if (InputX == 0){
            _anim.SetBool("Running", false);
        }

        else
        {
            _anim.SetBool("Running", true);
        }

        if (InputY == 0){
            _anim.SetBool("Running", false);
        }
        
        else 
        {
            _anim.SetBool("Running", true);
        }

        if (transform.position.y > 0){
            _anim.SetTrigger("flipY");
        }

        rb.velocity = new Vector2(InputX * speed, InputY * speed);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "GreenEn"){
            Debug.Log("Hitting!");
            currentHealth -= 2f;
            
            _anim.SetTrigger("Hurt");
        }

        if (currentHealth <= 0){
            _anim.SetTrigger("Die");
            Destroy(this.gameObject, 1.5f);
            Lose.SetActive(true);
            DefeatMus.SetActive(true);
            Music.SetActive(false);
            Time.timeScale = 0f;
        }
    }


    public void TakeDamage(float amount){
        currentHealth -= amount;

        _anim.SetTrigger("Hurt");

        if (currentHealth <= 0){
            _anim.SetTrigger("Die");
            Destroy(this.gameObject, 1.5f);
            Lose.SetActive(true);
            Time.timeScale = 0f;
            DefeatMus.SetActive(true);
            Music.SetActive(false);
        }
    }

    public void TurnBack(){
        _anim.SetFloat("Verical", InputY);
    }

    void SpawningObjectsE(){
        Vector2 position = new Vector2(Random.Range(-8f, 8f),Random.Range(-2f, 2f));
        Instantiate(Enemy, position, Quaternion.identity);

        if(stopSpawning){
            CancelInvoke("SpawningObjectsE");
        }
    }
    

    void SpawningObjectsI(){
        Vector2 position2 = new Vector2(Random.Range(-8f, 8f),Random.Range(-2f, 2f));
        Instantiate(item, position2, Quaternion.identity);

        if(stopSpawning){
            CancelInvoke("SpawningObjectsI");
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
