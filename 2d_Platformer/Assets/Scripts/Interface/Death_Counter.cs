using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death_Counter : MonoBehaviour
{
    public Text Counter;
    public Player Player;
    private float Count;
    
    // Update is called once per frame
    void Update()
    {
        Counter.text = "Количество смертей: " + Player.Death ;
    }
}
