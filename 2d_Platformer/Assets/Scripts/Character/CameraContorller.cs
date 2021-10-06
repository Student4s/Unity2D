using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContorller : MonoBehaviour


{
    public GameObject Hero;
    public float dumping;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 NewPosition =  Vector3.Lerp(transform.position, Hero.transform.position, dumping * Time.deltaTime);
        transform.position = new Vector3(NewPosition.x, NewPosition.y, transform.position.z);
    }
    
}
