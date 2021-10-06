using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private GameObject Hero;
    public GameObject Explosion;
    private float offset = 270f;
    public float speed;
    
    void Start()
    {
        Hero = GameObject.FindWithTag("Player");
        if (Hero==null)
            Debug.Log("Hero not Founded");
            
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Hero.transform.position, speed * Time.deltaTime);
        
        Vector2 difference = Hero.transform.position - transform.position;
        float rotate = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0f,0f,-rotate + offset );
        
    }
    void OnCollisionEnter2D(Collision2D Obj)
    {
        if (Obj.collider.CompareTag("Player"))
            Obj.collider.GetComponent<Player>().TakeDamage(3);
        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
   
}
