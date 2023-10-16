using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WeaponSelect : MonoBehaviour
{
    public GameObject[] weaponButtons;      // 무기 배열
    public int maxWeaponSelect = 5;         // 선택 가능한 최대 무기 수
    public List<GameObject> selectedWeapons = new List<GameObject>(); // 선택된 무기 리스트
    public Button gameStartButton;          // 게임 시작 버튼


    private void Start()
    {
        // 처음에는 게임 시작 버튼 비활성화
        gameStartButton.interactable = false;
    }


    public void WeaponSelection(GameObject weaponButton)
    {


        if (selectedWeapons.Contains(weaponButton))
        {
            // 이미 선택된 무기 클릭시 선택 해제
            selectedWeapons.Remove(weaponButton);
        }
        else if (selectedWeapons.Count < maxWeaponSelect)
        {
            // 보유 가능한 최대 무기 수를 아직 고르지 않았으면 무기 선택
            selectedWeapons.Add(weaponButton);
        }

        // 선택된 무기 수에 따라 게임 시작 버튼 활성화
        gameStartButton.interactable = selectedWeapons.Count == maxWeaponSelect;


        // 선택한 무기의 색 강조
        HighlightSelectedWeapons();


    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }


    private void HighlightSelectedWeapons()
    {
        foreach (GameObject weaponButton in weaponButtons)
        {

            bool isSelected = selectedWeapons.Contains(weaponButton);
            weaponButton.GetComponent<Image>().color = isSelected ? Color.green : Color.white;
        }

    }


}
