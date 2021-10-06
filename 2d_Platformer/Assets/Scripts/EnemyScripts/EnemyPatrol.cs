using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform FirstPoint;
    public Transform SecondPoint;
    private Transform spot;
    [SerializeField]private SpriteRenderer sp;
    
    void Start()
    {
        spot = FirstPoint;
        sp = GetComponent<SpriteRenderer>();
    }
    
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, spot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, FirstPoint.position) < 0.1f)
        {
            spot = SecondPoint;
            sp.flipX=true;
        }
        if (Vector2.Distance(transform.position, SecondPoint.position) < 0.1f)
        {
            spot = FirstPoint;
            sp.flipX=false;
        }
    }
    
    void OnCollisionEnter2D(Collision2D Obj)
        {
            if (Obj.collider.CompareTag("Player"))
            {
                Obj.collider.GetComponent<Player>().TakeDamage(100);
                Destroy(gameObject);
            }
            
                
        }
}
