using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopPopup : MonoBehaviour
{
    ShopEvent shopEvent;

    private TextMeshProUGUI productNametext;
    private TextMeshProUGUI productDesctext;



    

    public string[] heroName = { "Hero1", "Hero2", "Hero3" };
    public string[] heroDesc = { "Hero1 영웅 설명입니다. Hero1 영웅 설명입니다. Hero1 영웅 설명입니다. Hero1 영웅 설명입니다. Hero1 영웅 설명입니다.",
                                 "Hero2 영웅 설명입니다. Hero2 영웅 설명입니다. Hero2 영웅 설명입니다. Hero2 영웅 설명입니다. Hero2 영웅 설명입니다. ",
                                 "Hero3 영웅 설명입니다. Hero3 영웅 설명입니다. Hero3 영웅 설명입니다. Hero3 영웅 설명입니다. Hero3 영웅 설명입니다. "};


    public string[] towerName = { "레이저 타워", "화염 방사 타워", "기관총 타워", "미사일 타워", "기타", "등등" };
    public string[] towerDesc = { "단일 타격(1 대 1) / 발포 속도 : 0.5s / 화력 2",
                                  "범위 타격(짧은 사거리) / 발포 속도 : 2s / 화력 4",
                                  "단일 타격(1 대 1) / 발포 속도 : 0.1s / 화력 1",
                                  "범위 타격(넓은 사거리) / 발포 속도 : 3s / 화력 5",
                                  "추후", 
                                  "추가예정"};

    public string[] skillName = { "폭탄", "바리게이트", "버프" };
    public string[] skillDesc = { "적에게 폭탄을 던져 광역 피해를 입힙니다.",
                                  "적의 통행로를 일정 시간동안 막는 바리게이트를 설치합니다.",
                                  "플레이어의 주위에 있는 타워에게 공격력 향상 버프를 제공합니다."};

    public string[] equipName = { "망치", "총"};
    public string[] equipDesc = { "기본 망치입니다. 타워를 설치하고 장애물을 파괴합니다.\n설치 속도 : 3s\n장애물 파괴 속도 : 5s",
                                  "적을 처치하는 에너지 기반 무기입니다.\n공격력 : 1\n공격 속도 : 1\n탄창 : 10"};



    // Start is called before the first frame update
    void Start()
    {
        shopEvent = GameObject.Find("ShopEvent").GetComponent<ShopEvent>();

        Transform productName = transform.GetChild(1);
        Transform productDesc = transform.GetChild(3);

        productNametext = productName.GetComponent<TextMeshProUGUI>();
        productDesctext = productDesc.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(shopEvent != null)
        {
            if (shopEvent.selectedMenu == 0)
            {
                switch (shopEvent.selectedProduct)
                {
                    case 0:
                        productNametext.text = heroName[0];
                        productDesctext.text = heroDesc[0];
                        break;
                    case 1:
                        productNametext.text = heroName[1];
                        productDesctext.text = heroDesc[1];
                        break;
                    case 2:
                        productNametext.text = heroName[2];
                        productDesctext.text = heroDesc[2];
                        break;
                }
            }
            else if (shopEvent.selectedMenu == 1)
            {
                switch (shopEvent.selectedProduct)
                {
                    case 0:
                        productNametext.text = towerName[0];
                        productDesctext.text = towerDesc[0];
                        break;
                    case 1:
                        productNametext.text = towerName[1];
                        productDesctext.text = towerDesc[1];
                        break;
                    case 2:
                        productNametext.text = towerName[2];
                        productDesctext.text = towerDesc[2];
                        break;
                    case 3:
                        productNametext.text = towerName[3];
                        productDesctext.text = towerDesc[3];
                        break;
                    case 4:
                        productNametext.text = towerName[4];
                        productDesctext.text = towerDesc[4];
                        break;
                    case 5:
                        productNametext.text = towerName[5];
                        productDesctext.text = towerDesc[5];
                        break;
                }
            }
            else if (shopEvent.selectedMenu == 2)
            {
                switch (shopEvent.selectedProduct)
                {
                    case 0:
                        productNametext.text = skillName[0];
                        productDesctext.text = skillDesc[0];
                        break;
                    case 1:
                        productNametext.text = skillName[1];
                        productDesctext.text = skillDesc[1];
                        break;
                    case 2:
                        productNametext.text = skillName[2];
                        productDesctext.text = skillDesc[2];
                        break;
                }
            }
            else if (shopEvent.selectedMenu == 3)
            {
                switch (shopEvent.selectedProduct)
                {
                    case 0:
                        productNametext.text = equipName[0];
                        productDesctext.text = equipDesc[0];
                        break;
                    case 1:
                        productNametext.text = equipName[1];
                        productDesctext.text = equipDesc[1];
                        break;
                }
            }
        }
        
    }

    
    
}
