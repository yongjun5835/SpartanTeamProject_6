using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameObject[] NoUse;
    public void DontDestroyThis()
    {
        DontDestroyOnLoad(this);
        foreach(var t in NoUse)
        {
            t.SetActive(false);
        }
    }
}
