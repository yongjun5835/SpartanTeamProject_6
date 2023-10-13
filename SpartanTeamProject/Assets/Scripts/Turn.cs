using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turn : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemys;

    public int TurnCount = 0;
    private void Awake()
    {
        GameObject Player = GameManager.Instance.Player;
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public bool CheckTurn()
    {
        bool result = false;
        // 결과가 True일 때 Player턴, False일 때 Enemy턴
        if (TurnCount / Enemys.Length == 1)
        {
            TurnCount++;
            result = true;
        }
        else
        {
            TurnCount++;
            result = false;
        }
        if(TurnCount == Enemys.Length)
        {
            TurnCount = 0;
        }
        return result;
    }

    public void TurnStart()
    {
        if (CheckTurn())
        {
            // Player 동작 가능
            //Player.gameObject.GetComponent<Playertest>().enabled = true;
            // GetComponent<플레이어 동작 스크립트> << 삽입
        }
        else
        {
            // Enemy 동작가능
            //for(int i = 0; i<Enemys.Length; i++)
            //{
            //    Enemys[i].gameObject.GetComponent<Enemytest>().enabled = true;
            // GetComponent<적 동작 스크립트> << 삽입
            //}
        }
    }
}
