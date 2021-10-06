using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lifetime >= 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            lifetime -= Time.deltaTime;
        }
        else
            Destroy(gameObject);
    }
    
    void OnCollisionEnter2D(Collision2D Obj)
    {
        if (Obj.collider.CompareTag("Enemy"))
            Obj.collider.GetComponent<Enemy>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
