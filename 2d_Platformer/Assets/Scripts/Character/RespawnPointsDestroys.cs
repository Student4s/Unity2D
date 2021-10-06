using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPointsDestroys : MonoBehaviour
{
   

    void OnCollisionEnter2D(Collision2D Obj)
    {
        if (Obj.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
            
                
    }
}
