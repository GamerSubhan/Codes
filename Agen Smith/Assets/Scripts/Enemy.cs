using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public Transform player;
    private float speed = 1.5f;
    [SerializeField] float greenHealth;
    [SerializeField] float maxHealth = 100f;
    void Start()
    {
        greenHealth = maxHealth;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Attack();
    }

    void Attack(){
        anim.SetBool("Attacking", true);
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void TakeDamage(float amount){
        greenHealth -= amount;
        anim.SetTrigger("Hurt");
        
        if(greenHealth <= 0){
            Die();
        }
    }

    void Die(){
        anim.SetTrigger("Die");
        Destroy(gameObject);
    }

    
}
