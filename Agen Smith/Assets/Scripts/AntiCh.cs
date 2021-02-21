using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiCh : MonoBehaviour
{
    public Transform player;
    private float speed = 2f;
    public Animator anim;
    private float maxHealth = 150f;
    public float AntiHealth;
    public Transform colliderPoint;
    public float colliderRange;
    public LayerMask playerLayer;
    [SerializeField] private GameObject Win, VictoryMus, Music;
    [SerializeField] GameObject _laser;
    public float spawnTime;
    public float spawnDelay;

    bool IsSpawning = false;
    void Start()
    {
        AntiHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Attack();
        Collider2D[] collider = Physics2D.OverlapCircleAll(colliderPoint.position, colliderRange, playerLayer);
        foreach(Collider2D enemy in collider){
            enemy.GetComponent<Player>().TakeDamage(.5f);
        }
        
    }

    void Attack(){
        InvokeRepeating("SpawnLaser", spawnTime, spawnDelay);

        float distance = Vector2.Distance(transform.position, player.position);
        float lineOfSite = 5f;

        if (lineOfSite >= distance){
            anim.SetBool("ShotPOS", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
    public void TakeDamage(float amount){
        AntiHealth -= amount;
        anim.SetTrigger("Damage");
        
        if(AntiHealth <= 0){
            Die();
        }
    }

    void Die(){
        anim.SetTrigger("Die");
        Destroy(gameObject, 2f);
        Win.SetActive(true);
        Music.SetActive(false);
        VictoryMus.SetActive(true);
        Time.timeScale = 0f;
    }

    void SpawnLaser(){
        if(IsSpawning){
            CancelInvoke("SpawnLaser");
        }

        Instantiate(_laser, transform.position, Quaternion.identity);
    }
}
