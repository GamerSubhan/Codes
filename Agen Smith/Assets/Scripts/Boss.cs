using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    private float speed = 3f;
    public Animator anim;
    private float maxHealth = 150f;
    private float BossHealth;
    public Transform colliderPoint;
    public float colliderRange;
    public LayerMask playerLayer;
    [SerializeField] private GameObject Win, VictoryMus, Music;
    void Start()
    {
        BossHealth = maxHealth;
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
        float distance = Vector2.Distance(transform.position, player.position);
        float lineOfSite = 8f;

        if (lineOfSite >= distance){
            anim.SetBool("Attack", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }


    public void TakeDamage(float amount){
        BossHealth -= amount;
        anim.SetTrigger("Hurt");
        
        if(BossHealth <= 0){
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
}
