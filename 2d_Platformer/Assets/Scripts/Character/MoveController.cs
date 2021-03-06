using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    public float speed = 2f;
    private Rigidbody2D rb;
    [SerializeField] private bool Face = true;
    
    public float JumpForce;
    [SerializeField]private bool IsGround=true;
    [SerializeField]private int JumpCounter=2;
    public int MaxJumpCount = 2;

    public bool IsDash=false;
    private int DashCounter = 1;
    public int MaxDashCounter = 1;
    public float DashForce=750f;
    [SerializeField] private float Dash_delay = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        Moves();
        Jump();
        Dash();
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        Face = !Face;
    }

    void Moves()
    {
        float moveInput = Input.GetAxis("Horizontal");
        
        if (moveInput!=0) 
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        else
        { 
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
           

        if (!Face && moveInput > 0)
            Flip();

        if (Face && moveInput < 0)
            Flip();
    }

    void Jump()
    {
        if (IsGround)
            JumpCounter = MaxJumpCount;
        if (Input.GetKeyDown(KeyCode.Space) && JumpCounter > 0 ) 
        {
            JumpCounter -= 1;
            IsGround = false;
            rb.velocity=Vector2.up * JumpForce;
        }
    }

    void Dash()
    {
        if (Input.GetMouseButton(1) && DashCounter > 0 && IsDash)
        {
            if (Dash_delay<0) 
                if (Face) 
                {
                    rb.AddForce(Vector2.right * DashForce);
                    //Dash_delay = 1f; 
                }
                else 
                {
                    rb.AddForce(Vector2.left * DashForce);
                   // Dash_delay = 1f; 
                }
        }

        //Dash_delay -= Time.deltaTime;
    }
    void OnCollisionEnter2D(Collision2D Obj)
    {
        IsGround = true;
        DashCounter = MaxDashCounter;
    }

}

