using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string SceneName;
    public int SelectedStage;
    public void SceneChange()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void StageNum()
    {
        StageManager.Instance.StageNumber = SelectedStage;
    }
}
