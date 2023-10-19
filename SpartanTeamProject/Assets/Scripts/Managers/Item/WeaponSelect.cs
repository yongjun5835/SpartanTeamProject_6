using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WeaponSelect : MonoBehaviour
{
    public GameObject[] weaponButtons;      // 무기 배열
    public int maxWeaponSelect = 5;         // 선택 가능한 최대 무기 수
    public List<GameObject> selectedWeapons = new List<GameObject>(); // 선택된 무기 리스트
    public Button gameStartButton;          // 게임 시작 버튼
    public Transform weaponSlotPanel;
    public GameObject[] NoUse;
    public GameObject WeaponUI;

    private void Start()
    {
        // 처음에는 게임 시작 버튼 비활성화
        gameStartButton.interactable = false;
        gameStartButton.onClick.AddListener(StartGame);
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
            selectedWeapons[selectedWeapons.Count - 1].tag = weaponButton.tag;
            Debug.Log(weaponButton.tag);
        }

        // 선택된 무기 수에 따라 게임 시작 버튼 활성화
        gameStartButton.interactable = selectedWeapons.Count == maxWeaponSelect;

        UpdateWeaponSlots();
        // 선택한 무기의 색 강조
        HighlightSelectedWeapons();


    }

    public void StartGame()
    {
        if(GameManager.Instance.StageNumber == 1)
        {
            SceneManager.LoadScene("Stage1");
        }else if (GameManager.Instance.StageNumber == 2)
        {
            SceneManager.LoadScene("Stage2");
        }else if (GameManager.Instance.StageNumber == 3)
        {
            SceneManager.LoadScene("Stage3");
        }
        DontDestroyOnLoad(WeaponUI);
        foreach(var t in NoUse)
        {
            t.SetActive(false);
        }
    }


    private void HighlightSelectedWeapons()
    {
        foreach (GameObject weaponButton in weaponButtons)
        {

            bool isSelected = selectedWeapons.Contains(weaponButton);
            weaponButton.GetComponent<Image>().color = isSelected ? Color.white : Color.gray;
        }

    }

    public void UpdateWeaponSlots()
    {
       
        int currentSlotCount = weaponSlotPanel.childCount;

        
        foreach (Transform slot in weaponSlotPanel)
        {
            Destroy(slot.gameObject);
        }

        
        int maxSlotCount = 5;

        
        for (int i = 0; i < Mathf.Min(maxSlotCount, selectedWeapons.Count); i++)
        {
            GameObject selectedWeapon = selectedWeapons[i];
            GameObject slot = new GameObject("WeaponSlot");
            slot.tag = selectedWeapon.tag;
            slot.transform.SetParent(weaponSlotPanel); 

           
            Image selectedWeaponImage = selectedWeapon.GetComponent<Image>();

           
            Image slotImage = slot.AddComponent <Image>();
            slotImage.sprite = selectedWeaponImage.sprite; // 부모 게임 오브젝트의 이미지를 슬롯 이미지로 설정

            if (i == 0)
            {
                // 첫 번째 슬롯 (장착 상태)의 알파 값을 1로 설정
                slotImage.color = new Color(1, 1, 1, 1);
            }
            else
            {
                // 나머지 슬롯 (장착되지 않은 상태)의 알파 값을 0.4로 설정
                slotImage.color = new Color(1, 1, 1, 0.4f);
            }

            // 슬롯에 버튼 컴포넌트 추가
            Button slotButton = slot.AddComponent<Button>();
            slotButton.onClick.AddListener(delegate { ProjectileManager.instance.selectBtn(slotButton.gameObject.tag); });
           
            int slotIndex = i; // 슬롯의 인덱스 저장
            slotButton.onClick.AddListener(() => SlotClicked(slotIndex));
        }
    }


    private void SlotClicked(int slotIndex)
    {
        // 슬롯 인덱스에 따라 다른 동작을 수행
        for (int i = 0; i < selectedWeapons.Count; i++)
        {
            Image slotImage = weaponSlotPanel.GetChild(i).GetComponent<Image>();
            if (i == slotIndex)
            {
                // 클릭한 슬롯 (선택 상태)의 알파 값을 1로 설정
                slotImage.color = new Color(1, 1, 1, 1);
            }
            else
            {
                // 다른 슬롯 (선택되지 않은 상태)의 알파 값을 0.4로 설정
                slotImage.color = new Color(1, 1, 1, 0.4f);
            }
        }

    }
}
