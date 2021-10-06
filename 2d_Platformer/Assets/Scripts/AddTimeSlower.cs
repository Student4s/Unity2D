using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimeSlower : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D Obj)
    {
        if (Obj.collider.CompareTag("Player"))
        {
            Obj.collider.GetComponent<ZaWarudo_TimeSlower>().IsActive = true;
            Destroy(gameObject);
        }
    }
}
