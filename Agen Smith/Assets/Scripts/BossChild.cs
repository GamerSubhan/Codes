using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChild : MonoBehaviour
{
    public Transform player;
    private float speed = 4f;
    public Animator anim;
    private float maxHealth = 10f;
    private float BossHealth;
    public Transform colliderPoint;
    public float colliderRange;
    public LayerMask playerLayer;

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
            enemy.GetComponent<Player>().TakeDamage(.3f);
        }
        
    }

    void Attack(){

        anim.SetBool("Attack", true);
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
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
    }
}

