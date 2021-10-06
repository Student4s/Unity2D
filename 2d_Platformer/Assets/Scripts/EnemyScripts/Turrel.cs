using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrel : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject ShootPoint;
    public GameObject Player;

    public float timeBTWshoot =0.1f;
    private float CurrenttimeBTWshoot=0.1f;
    public float VisionRadius = 10;
    private float offset = 90f;
    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        Vector2 difference = Player.transform.position - transform.position;
        float rotate = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0f,0f,-rotate + offset );

        if (Vector2.Distance(transform.position, Player.transform.position)<=VisionRadius)
            if (CurrenttimeBTWshoot <= 0)
            {
                Instantiate(Bullet, ShootPoint.transform.position, transform.rotation);
                CurrenttimeBTWshoot = timeBTWshoot;
            }
                
            else
                CurrenttimeBTWshoot -= Time.deltaTime;
    }
}
