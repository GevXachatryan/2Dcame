using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnichtojitelObektov : MonoBehaviour
{

    public GameObject Ob;
    void OnTriggerEnter2D(Collider2D other)                     //Метод отвечает за смерть игрока 
    {

        if (other.tag == "Obj")
        {
            Destroy(Ob);
        }
    }
}