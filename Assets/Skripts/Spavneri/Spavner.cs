using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spavner : MonoBehaviour
{

    public Transform SpawnPos;
    public GameObject Cube;
    public float timeSpawn;



    





    void Start()
    {
        StartCoroutine(SpawnCD());
    }

  

    void Repeat()
    {
        StartCoroutine(SpawnCD());
    }


    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(timeSpawn);
        Instantiate(Cube, SpawnPos.position, Quaternion.identity);
        Repeat();
    }


    //private void FixedUpdate()
    //{


    //        transform.Translate(new Vector2(4f, 0) * Time.deltaTime);
        


        
    //}
}
