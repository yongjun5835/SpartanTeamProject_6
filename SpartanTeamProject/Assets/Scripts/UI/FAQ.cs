using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FAQ : MonoBehaviour
{
    public Button Btnn;
    public GameObject Option;
 
    bool pause = false;
    public void ToggleOption()
    {
        if (Option.activeSelf == false)
        {
            Option.SetActive(true); // 스크립트를 활성화
        }
        else
        {
            Option.SetActive(false); // 스크립트를 비활성화
        }
    }


    void Update()
    {
        
    }
}
