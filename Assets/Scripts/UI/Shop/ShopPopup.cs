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
    public string[] heroDesc = { "Hero1 ���� �����Դϴ�. Hero1 ���� �����Դϴ�. Hero1 ���� �����Դϴ�. Hero1 ���� �����Դϴ�. Hero1 ���� �����Դϴ�.",
                                 "Hero2 ���� �����Դϴ�. Hero2 ���� �����Դϴ�. Hero2 ���� �����Դϴ�. Hero2 ���� �����Դϴ�. Hero2 ���� �����Դϴ�. ",
                                 "Hero3 ���� �����Դϴ�. Hero3 ���� �����Դϴ�. Hero3 ���� �����Դϴ�. Hero3 ���� �����Դϴ�. Hero3 ���� �����Դϴ�. "};


    public string[] towerName = { "������ Ÿ��", "ȭ�� ��� Ÿ��", "����� Ÿ��", "�̻��� Ÿ��", "��Ÿ", "���" };
    public string[] towerDesc = { "���� Ÿ��(1 �� 1) / ���� �ӵ� : 0.5s / ȭ�� 2",
                                  "���� Ÿ��(ª�� ��Ÿ�) / ���� �ӵ� : 2s / ȭ�� 4",
                                  "���� Ÿ��(1 �� 1) / ���� �ӵ� : 0.1s / ȭ�� 1",
                                  "���� Ÿ��(���� ��Ÿ�) / ���� �ӵ� : 3s / ȭ�� 5",
                                  "����", 
                                  "�߰�����"};

    public string[] skillName = { "��ź", "�ٸ�����Ʈ", "����" };
    public string[] skillDesc = { "������ ��ź�� ���� ���� ���ظ� �����ϴ�.",
                                  "���� ����θ� ���� �ð����� ���� �ٸ�����Ʈ�� ��ġ�մϴ�.",
                                  "�÷��̾��� ������ �ִ� Ÿ������ ���ݷ� ��� ������ �����մϴ�."};

    public string[] equipName = { "��ġ", "��"};
    public string[] equipDesc = { "�⺻ ��ġ�Դϴ�. Ÿ���� ��ġ�ϰ� ��ֹ��� �ı��մϴ�.\n��ġ �ӵ� : 3s\n��ֹ� �ı� �ӵ� : 5s",
                                  "���� óġ�ϴ� ������ ��� �����Դϴ�.\n���ݷ� : 1\n���� �ӵ� : 1\nźâ : 10"};



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
