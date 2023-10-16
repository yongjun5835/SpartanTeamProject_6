using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            return instance == null ? null : instance;
        }
    }

    public GameObject Player;
    public Text timer;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        float time = float.Parse(timer.text);
        time -= Time.deltaTime;
        timer.text = time.ToString("N2");
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        Invoke(nameof(ReloadScene), 3f);
    }

    public void GameClear()
    {
        // 플레이어의 체력이 0이하로 내려가면 실행
        // UI의 다음 레벨, 메인메뉴로 화면 불러오기
    }

    public void ReloadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("IntroScene");
    }
}
