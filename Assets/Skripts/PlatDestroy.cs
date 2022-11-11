using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatDestroy : MonoBehaviour
{

    public GameObject platform;


    void OnTriggerEnter2D(Collider2D other)                    
    {

        if (other.tag == "Player")
        {
            Destroy(platform,1f);
        }

    }
}
