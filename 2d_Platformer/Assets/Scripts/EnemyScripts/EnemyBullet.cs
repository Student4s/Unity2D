using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public float damage;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    
    void OnCollisionEnter2D(Collision2D Obj)
    {
        if (Obj.collider.CompareTag("Player"))
            Obj.collider.GetComponent<Player>().TakeDamage(damage);
        Destroy(gameObject);
    }
}

