using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUpdate : MonoBehaviour
{
    

    void OnTriggerEnter2D(Collider2D other)                   
    {


        if (other.tag == "Player")
        {
           
            Timer.timeLeft = 25f;

        }
    }
}
