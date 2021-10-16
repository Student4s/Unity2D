using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adv_player_contr : MonoBehaviour
{
    public float _speed = 2f;
    private Rigidbody2D rb;
    public Camera CameraMain;
    private float _offset = 90f;
    
    public delegate void AtackByShoot();

    public static event AtackByShoot Atack;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float _moveInputX = Input.GetAxis("Horizontal");
        float _moveInputY = Input.GetAxis("Vertical");
        
        rb.velocity = new Vector2(_moveInputX * _speed, _moveInputY * _speed);
        
        Vector2 difference = CameraMain.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotate = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0f,0f,-rotate + _offset );

        if (Input.GetMouseButton(0))
        {
            Atack();
        }
    }
}
