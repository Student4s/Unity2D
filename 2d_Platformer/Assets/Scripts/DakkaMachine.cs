using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DakkaMachine : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject ShootPoint;

    public float timeBTWshoot =0.1f;
    private float CurrenttimeBTWshoot=0;

    public float ReloadTime=1f;
    private float offset = 90f;
    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
            if (CurrenttimeBTWshoot <= 0)
            {
                Instantiate(Bullet, ShootPoint.transform.position, transform.rotation);
                CurrenttimeBTWshoot = timeBTWshoot;
            }
                
            else
                CurrenttimeBTWshoot -= Time.deltaTime;
            
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotate = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0f,0f,-rotate + offset );
    }
}
