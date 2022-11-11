using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{


public void RestartLvle()
    {

        
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;


    }








}
