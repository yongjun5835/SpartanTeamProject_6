using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FAQ : MonoBehaviour
{
    public Button Btnn;
    public GameObject Option;
 
    bool pause = false;
    public void StopTime()
    {
        Option.SetActive(true);
        if (Option.activeSelf == true && !pause)
        {
            pause = true;
            Time.timeScale = 0;
        }
        else if (Option.activeSelf == true && pause)
        {
            pause = false;
            Option.SetActive(false);
            Time.timeScale = 1;
        }


      
    }


    void Update()
    {
        
    }
}
