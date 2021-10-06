using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZaWarudo_TimeSlower : MonoBehaviour
{
    public float Mana = 1f;
    private bool Timestop = false; //переключатель способности
    [SerializeField]private float delay = 0f; //задержка между вызовами. Чтобы не было двойного клика
    public bool IsActive=false;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.T) &&delay<0 && IsActive)
        {
            Timestop = true;
        }

        if (Timestop&&Mana>0)
        {
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = 1f / 100;
            Mana -= Time.fixedDeltaTime;
        }
        else
        if(Mana<=0)
        {
            delay = 6;
            Mana = 2;
            Timestop = false;
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 1f / 50;
        }
        
        delay -= Time.fixedDeltaTime;
    }

}
