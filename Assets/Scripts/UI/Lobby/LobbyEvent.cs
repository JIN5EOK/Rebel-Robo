using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LobbyEvent : MonoBehaviour
{
    
    public GameObject StageMenu;
    public GameObject blackFilter;

    public GameObject OptionMenu;

    public GameObject ShopMenu;

    public GameObject BackGround;
    public GameObject BackGround2;
    public GameObject BackGround3;
    public GameObject[] bgArray;



    public GameObject Heros;
    public GameObject Hammers;

    public bool[] HeroboolArray = { true, false, false };
    public bool[] DiffiboolArray = { true, false, false };

    public TextMeshProUGUI ChapterName;
    public TextMeshProUGUI coinAmount;

    public bool stageMenuOn = false; //Stage ���� ���� �� ��ȯ ���ϰ�

    GameManager gameManager;
    MissionData missionData;

    public float blurAmount = 0.5f; // �帮�� ������� ����

    public static LobbyEvent Instance;


    // ��ư Ŭ�� �� ȣ��Ǵ� �Լ��Դϴ�.
    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        missionData = GameObject.Find("MissionData").GetComponent<MissionData>();

        bgArray = new GameObject[] { BackGround, BackGround2, BackGround3 };
        
    }

    public void Update()
    {
        if(StageMenu != null)
        {
            if (StageMenu.activeSelf)
            {
                gameManager.stageMenuOn = true;
            }
            else
                gameManager.stageMenuOn = false;
        }
        

        coinAmount.text = gameManager.coin.ToString();



    }

    public void IntroButton()
    {
        SceneManager.LoadScene("GameLobby");
    }
    
    public void StageButtonClicked(int stageNumber)
    {
        if(StageMenu != null)
        {
            StageMenu.SetActive(true);
            TextMeshProUGUI stageNumberText = StageMenu.transform.Find("StageNumber").GetComponent<TextMeshProUGUI>();
            string stageID = gameManager.chapterNumber + "-" + stageNumber.ToString();

            stageNumberText.SetText(stageID);

            HeroboolArray[0] = true;
            DiffiboolArray[0] = true;
            for (int i = 1; i < 3; i++)
            {
                HeroboolArray[i] = false;
                DiffiboolArray[i] = false;
            }

            Transform questMenu = StageMenu.transform.Find("Quests");
            TextMeshProUGUI[] textMeshPros = questMenu.GetComponentsInChildren<TextMeshProUGUI>();

            for (int i = 0; i < textMeshPros.Length; i++)
            {
                int row = gameManager.stageNumber-1; // stageNumber�� ���� �� �ε����� �����մϴ�.
                int col = i; // �ڽ� ������Ʈ�� �ε����� �� �ε����� ��ġ��ŵ�ϴ�.

                textMeshPros[i].text = missionData.MissionArray[row, col];
                
            }
        }

        CanvasGroup[] canvasGroups = FindObjectsOfType<CanvasGroup>();

        foreach (CanvasGroup canvasGroup in canvasGroups)
        {
            // StageMenu�� Canvas Group�� �ǳʶ�
            if (canvasGroup.gameObject == StageMenu)
            {
                canvasGroup.alpha = 1f; // StageMenu�� alpha ���� 1�� �����Ͽ� ���̵��� ��
                canvasGroup.interactable = true;
            }

            else
            {
                canvasGroup.alpha = 0.3f; // �ٸ� ������Ʈ�� alpha ���� 0.5�� �����Ͽ� ��Ӱ� ó��
                canvasGroup.interactable = false;
            }
        }

        printEquip();


    }
    public void ExitStageMenu()
    {
        if (StageMenu != null)
        {
            StageMenu.SetActive(false);
        }
            
        
        CanvasGroup[] canvasGroups = FindObjectsOfType<CanvasGroup>();

        
        foreach (CanvasGroup canvasGroup in canvasGroups)
        {
            
            if (canvasGroup.gameObject == StageMenu)
            {
                continue;
            }

            
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
        }
        

    }
    public void BeforeStage()
    {
        if (StageMenu != null)
        {
            if (gameManager.chapterNumber != 1 && !gameManager.stageMenuOn)
            {
                if(bgArray != null)
                {
                    gameManager.chapterNumber--;
                    bgArray[gameManager.chapterNumber - 1].SetActive(true);
                    bgArray[gameManager.chapterNumber].SetActive(false);

                    ChapterName.text = "Chapter " + gameManager.chapterNumber.ToString();
                }
                
            }
        }
        
    }
    
    public void NextStage()
    {
        if(StageMenu != null)
        {
            if (gameManager.chapterNumber != 2 && !gameManager.stageMenuOn)
            {
                if (bgArray != null)
                {
                    gameManager.chapterNumber++;
                    bgArray[gameManager.chapterNumber - 1].SetActive(true);
                    bgArray[gameManager.chapterNumber - 2].SetActive(false);

                    ChapterName.text = "Chapter " + gameManager.chapterNumber.ToString();

                }
            }
        }
        
    }

    private void printEquip()
    {
        Heros.transform.GetChild(0).transform.GetChild(gameManager.heroIndex).gameObject.SetActive(true);
        Hammers.transform.GetChild(0).transform.GetChild(gameManager.hammerIndex).gameObject.SetActive(true);
    }
    

    public void OptionClicked()
    {
        if(OptionMenu != null)
        {
            OptionMenu.SetActive(true);
        }
        
    }
    public void ExitOptionMenu()
    {
        if (OptionMenu != null)
        {
            OptionMenu.SetActive(false);
        }

    }

    public void ShopClicked()
    {
        SceneManager.LoadScene("Shop");
    }

    public void loadGame()
    {
        LoadSceneManager.LoadScene("DesingDevelop");
    }

}
