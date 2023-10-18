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
    public Text EnemyLeft;
    float time = 10f;
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
        time -= Time.deltaTime;
        timer.text = time.ToString("N2");
        int EnemyCount = Enemys.Length;
        EnemyLeft.text = "³²Àº Àû : " + EnemyCount.ToString();
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
        if (Enemys.Length == 0)
            return false;

        if (TurnCount % (Enemys.Length+1) == 0)
        {
            result = true;
        }
        else
        {
            result = false;
        }
        //if (TurnCount > Enemys.Length + 1)
        //{
        //    TurnCount = 0;
        //}
        return result;
    }
    public void TurnStart()
    {
        if (TurnCount % (Enemys.Length +1) == Enemys.Length)
        {
            Player.gameObject.GetComponent<PlayerController>().IsMyTurn = true;
        }
        else
        {
            if (TurnCount % (Enemys.Length + 1) == 0)
            {
                Enemys[0].gameObject.GetComponent<Enemy>().IsMyTurn = true;
            }
            else
            {
                Enemys[TurnCount % (Enemys.Length + 1)].gameObject.GetComponent<Enemy>().IsMyTurn = true;
            }
        }
    }
    public void TurnEnd()
    {
        if (TurnCount % (Enemys.Length + 1) -1 == Enemys.Length)
        {
            Player.gameObject.GetComponent<PlayerController>().IsMyTurn = false;
            Player.gameObject.GetComponent<PlayerController>().Refresh();
        }
        else
        {
            // Enemys[TurnCount].gameObject.GetComponent<EnemyTest>().enabled = false;
            if (TurnCount % (Enemys.Length + 1)-1 < 0)
            {
                Enemys[0].gameObject.GetComponent<Enemy>().IsMyTurn = false;
            }
            else
            {
                Enemys[TurnCount % (Enemys.Length + 1) - 1].gameObject.GetComponent<Enemy>().IsMyTurn = false;
            }
        }
    }

    IEnumerator Turn()
    {
        while (true)
        {
            IsCourutineRunning = true;
            TurnStart();

            yield return new WaitForSeconds(time);
            TurnEnd();
            IsCourutineRunning = false;
        }
    }
}
