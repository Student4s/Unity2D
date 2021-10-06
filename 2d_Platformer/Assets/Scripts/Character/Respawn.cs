using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject RespawnPoint;

    public GameObject Hero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Re()
    {
        Instantiate(Hero,RespawnPoint.transform.position, RespawnPoint.transform.rotation);
    }
}
