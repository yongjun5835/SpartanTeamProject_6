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
    [SerializeField] private GameObject[] Enemys;

    [SerializeField] private GameObject Player;
    public CameraController cameraController;
    public int TurnCount;
    public Text timer;
    float time;
    bool result = false;
    bool IsCourutineRunning = false;

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

    private void Start()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }
    private void Update()
    {
        TurnCheck();
        time = float.Parse(timer.text);
        time -= Time.deltaTime;
        timer.text = time.ToString("N2");
        if (!IsCourutineRunning)
        {
            StartCoroutine(Turn());
        }
        if(time < 0)
        {
            time = 10f;
            timer.text = time.ToString() ;
            TurnCount++;
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        Invoke(nameof(ReloadScene), 3f);
    }

    public void GameClear()
    {

    }

    public void ReloadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("IntroScene");
    }
    public bool TurnCheck()
    {
        if (TurnCount / Enemys.Length == 1)
        {
            result = true;
        }
        else
        {
            result = false;
        }
        if (TurnCount > Enemys.Length)
        {
            TurnCount = 0;
        }
        return result;
    }
    public void TurnStart()
    {
        if (result)
        {
            Player.gameObject.GetComponent<PlayerController>().enabled = true;
        }
        else
        {
            Enemys[TurnCount].gameObject.GetComponent<EnemyTest>().enabled = true;
        }
    }
    public void TurnEnd()
    {
        if (result)
        {
            Player.gameObject.GetComponent<PlayerController>().enabled = false;
        }
        else
        {
            Enemys[TurnCount].gameObject.GetComponent<EnemyTest>().enabled = false;
        }
    }

    IEnumerator Turn()
    {
        while (true)
        {
            IsCourutineRunning = true;
            TurnStart();

            yield return new WaitForSecondsRealtime(time);
            TurnEnd();
            IsCourutineRunning = false;
        }
    }
}
