using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{ 
    public float speed = 2f; 
    private Rigidbody2D rb; 
    public float JumpForce;

    [SerializeField]private bool Face = true;
    private bool IsGround;
    public Transform GroundCheck;
    public float CheckRaidus;
    public LayerMask Ground;

    public int JumpCounter=2;
    //private float JumpDelay = 0; // задержка для повторного прыжка

 
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        IsGround = Physics2D.OverlapCircle(GroundCheck.position, CheckRaidus, Ground);

        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (!Face && moveInput > 0)
            Flip();

        if (Face && moveInput < 0)
            Flip();
        /*if (Input.GetKeyDown(KeyCode.K))
        {
            Vector2 Dirrection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            Dirrection.Normalize();
            //Debug.Log(Dirrection);
            rb.velocity=new Vector2(0,0);
            rb.AddForce(Dirrection*5000);
        }*/
    }

    void Update()
    {
        if (IsGround)
            JumpCounter = 2;
        if (Input.GetKeyDown(KeyCode.Space) && JumpCounter > 0 /*&& JumpDelay <= 0*/) 
        {
            rb.velocity = Vector2.up * JumpForce;
            JumpCounter -= 1;
            //JumpDelay = 0.3f;
        }

        //JumpDelay -= Time.deltaTime;
    }

    void Flip()
    {
        Face = !Face;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
