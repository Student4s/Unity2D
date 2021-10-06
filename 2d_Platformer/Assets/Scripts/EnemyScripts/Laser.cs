using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float WorkTime = 5f;
    [SerializeField]private float CurrentTime = 0f;
    private bool Switcher = true; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Switcher)
        {
            if (CurrentTime >= 0)
                CurrentTime -= Time.deltaTime;
            else
            {
                CurrentTime = WorkTime;
                Switcher = false;
                //gameObject.SetActive(false);
                gameObject.GetComponent<BoxCollider2D>().enabled=false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if (!Switcher)
        {
            if (CurrentTime >= 0)
                CurrentTime -= Time.deltaTime;
            else
            {
                CurrentTime = WorkTime;
                Switcher = true;
                //gameObject.SetActive(true);
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
   
}
