using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public Animator anim;
    public float flyingHealth;
    public float maxHealth = 100f;
    public Transform player;
    private float speed = 3f;
    [SerializeField] private Transform colliderPoint;
    [SerializeField] private float colliderRange;
    [SerializeField] private LayerMask playerLayer;

    void Start()
    {
        flyingHealth = maxHealth;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    void  Update(){
        Attack();

        Collider2D[] collider = Physics2D.OverlapCircleAll(colliderPoint.position, colliderRange, playerLayer);
        foreach(Collider2D enemy in collider){
            enemy.GetComponent<Player>().TakeDamage(.5f);
        }
    }

    void Attack(){
        anim.SetBool("Attacking", true);
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void TakeDamage(float amount){
        flyingHealth -= amount;
        anim.SetTrigger("Hurt");
        
        if(flyingHealth <= 0){
            Die();
        }
    }

    void Die(){
        anim.SetTrigger("Die");
        Destroy(gameObject);
    }

}
