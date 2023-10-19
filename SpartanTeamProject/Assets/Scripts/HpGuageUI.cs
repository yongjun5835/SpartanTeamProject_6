using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpGuageUI : MonoBehaviour
{
    [SerializeField] private GameObject hpGauge;
    [SerializeField] private GameObject character;

    private Player player;
    private Enemy enemy;

    public bool isPlayer;

    private void Start()
    {
        if (character.tag == "Player")
        {
            player = character.GetComponent<Player>();
            player.OnHealthChange += Refresh;
            isPlayer = true;
        }
        if (character.tag == "Enemy")
        {
            enemy = character.GetComponent<Enemy>();
            enemy.OnHealthChange += Refresh;
            isPlayer = false;
        }
    }

    public void Refresh()
    {
        if (isPlayer) 
        {
            float percent = player.curHealth / player.maxHealth;
            Vector3 newScale = hpGauge.transform.localScale;
            newScale.x = percent;
            hpGauge.transform.localScale = newScale;
        }
        else
        {
            float percent = enemy.curHealth / enemy.maxHealth;
            Vector3 newScale = hpGauge.transform.localScale;
            newScale.x = percent;
            hpGauge.transform.localScale = newScale;
        }
    }
}
