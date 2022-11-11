using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCifri_Frukti : MonoBehaviour
{

    private GameObject player;
    private AudioSource audioSource;
    public AudioClip Cifri;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
    }



    void OnTriggerEnter2D(Collider2D col)                     
    {

        if (col.tag == "Player")
        {
            audioSource.PlayOneShot(Cifri);
        }

    }

}