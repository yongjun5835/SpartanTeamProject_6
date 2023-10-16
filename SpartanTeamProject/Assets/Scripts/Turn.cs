using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turn : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemys;

    public int TurnCount = 0;
    bool result = false;
    private void Awake()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public bool CheckTurn()
    {
        // 결과가 True일 때 Player턴, False일 때 Enemy턴
        if (TurnCount / Enemys.Length == 1)
        {
            result = true;
        }
        else
        {
            result = false;
        }
        TurnCount++;
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
            // Player 동작 가능
            GameManager.Instance.Player.gameObject.GetComponent<PlayerController>().enabled = true;
            // GetComponent<플레이어 동작 스크립트> << 삽입
        }
        else
        {
            // Enemy 동작가능
            Enemys[TurnCount-1].gameObject.GetComponent<EnemyTest>().enabled = true;
            //for(int i = 0; i<Enemys.Length; i++)
            //{
            //    enemys[i].gameobject.getcomponent<enemytest>().enabled = true;
            // GetComponent<적 동작 스크립트> << 삽입
            //}
        }
    }
    public void TurnEnd(GameObject obj)
    {
        //게임오브젝트를 받아서 동작 스크립트 enabled = false로 변경

    }

    public void TurnChange()
    {
        CheckTurn();
        TurnStart();
    }
}
