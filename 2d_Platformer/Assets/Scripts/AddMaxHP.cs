using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMaxHP : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D Obj)
    {
        if (Obj.collider.CompareTag("Player"))
        {
            Obj.collider.GetComponent<Player>().Maxhealth = 15;
            Destroy(gameObject);
        }
    }
}
