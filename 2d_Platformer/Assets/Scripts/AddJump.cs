using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddJump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D Obj)
    {
        if (Obj.collider.CompareTag("Player"))
        {
            Obj.collider.GetComponent<MoveController>().IsDash = true;
            Destroy(gameObject);
        }
    }
}
