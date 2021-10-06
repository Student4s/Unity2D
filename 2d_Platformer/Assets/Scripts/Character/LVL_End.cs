using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_End : MonoBehaviour
{
    public GameObject Image;
    void OnCollisionEnter2D(Collision2D Obj)
    {
        
        if (Obj.collider.CompareTag("Player"))
        {
            Image.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
