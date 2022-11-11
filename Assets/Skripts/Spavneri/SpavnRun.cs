using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpavnRun : MonoBehaviour
{
    public float speed;
    public Vector2 dir;
    public GameObject spavn;



    private void FixedUpdate()
    {
        transform.Translate(speed * dir * Time.deltaTime, Space.World);
    }
    void OnTriggerEnter2D(Collider2D other)                     //Метод отвечает за смерть игрока 
    {

        if (other.tag == "Player" || other.tag == "Utilizator")
        {
            Destroy(spavn);
        }

    }
}
