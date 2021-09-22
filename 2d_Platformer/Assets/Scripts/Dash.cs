using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{
    public float DashForse = 8f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector2 Dirrection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            Dirrection.Normalize();
            Debug.Log(Dirrection);
            rb.velocity=new Vector2(0,0);
            rb.AddForce(Dirrection*DashForse);
        }
    }
}
