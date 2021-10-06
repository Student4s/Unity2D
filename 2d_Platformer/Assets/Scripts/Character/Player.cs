using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health=10f;
    public float Maxhealth=10f;
    public Transform StartPoint;
    [SerializeField] private Vector3 RespawnPoint;
    public GameObject PauseMenu;
    public int Death;

    void Start()
    {
        RespawnPoint = StartPoint.transform.position;
        Death = 0;
    }

     void Update()
    {
        if (health <= 0)
        {
            transform.position = RespawnPoint;
            health = Maxhealth;
            Death++;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    
    void OnCollisionEnter2D(Collision2D Obj)
    {
        if (Obj.collider.CompareTag("Traps"))
        {
            transform.position = RespawnPoint;
            Death++;
        }
        
        if (Obj.collider.CompareTag("Portal"))
        {
            transform.position = new Vector3(26,2,0);
        }

        if (Obj.collider.CompareTag("Respawn"))
        {
            RespawnPoint = Obj.transform.position;
        }
        
        
    }
}
