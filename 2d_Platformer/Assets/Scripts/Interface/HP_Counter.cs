using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Counter : MonoBehaviour
{
    public Text Counter;
    public Player Player;
    private float Count;
    
    // Update is called once per frame
    void Update()
    {
        Counter.text = "HP: " + Player.health ;
    }
}
