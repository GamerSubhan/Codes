using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float speed = 3f;
    public SpriteRenderer player;
    public Transform CollisionTransform;
    public float collisionRange = .5f;
    public LayerMask EnemyLayer;
    public Transform CollisionTransform2, BossPoint, littlePoint;
    public float fieldPoint;
    public float collisionRange2 = .5f;
    public float Range;
    public LayerMask EnemyLayer2, BossLayer, littleLayer;

    void Start()
    {
        player = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        Destroy(this.gameObject, 1.3f);

        Collider2D[] collider = Physics2D.OverlapCircleAll(CollisionTransform.position, collisionRange, EnemyLayer);
        foreach(Collider2D enemy in collider){
            enemy.GetComponent<Enemy>().TakeDamage(30f);
        }

        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(CollisionTransform2.position, collisionRange2, EnemyLayer2);
        foreach(Collider2D enemy2 in collider2Ds){
            enemy2.GetComponent<Enemy2>().TakeDamage(5f);
        }

        Collider2D[] Laserr = Physics2D.OverlapCircleAll(BossPoint.position, fieldPoint, BossLayer);
        foreach(Collider2D Boss in Laserr){
            Boss.GetComponent<Boss>().TakeDamage(.1f);
        }

        Collider2D[] col = Physics2D.OverlapCircleAll(littlePoint.position, Range, littleLayer);
        foreach(Collider2D child in col){
            child.GetComponent<BossChild>().TakeDamage(60f);
        }

    } 

}
