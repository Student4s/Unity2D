using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    public GameObject Drone;
    public GameObject ShootPoint;
    
    public float timeBTWshoot =5f;
    private float CurrenttimeBTWshoot=0;
    private float VisionRadius = 15;
    public GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Player.transform.position)<=VisionRadius)
            if (CurrenttimeBTWshoot <= 0)
            {
                Instantiate(Drone, ShootPoint.transform.position, transform.rotation);
                CurrenttimeBTWshoot = timeBTWshoot;
            }
            else
                CurrenttimeBTWshoot -= Time.deltaTime;
    }
}
