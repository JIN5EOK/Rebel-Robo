using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameClick : MonoBehaviour
{

    

    InGameUI gameUI;
    MissionManager missionManager;
    //MoveText moveText;
     // ��ư�� ������ �־�� �ϴ� �ּ� �ð�
    private bool isButtonDown = false;

    private Button[] clickbuttons;
    public Button[] ClickButtons
    {
        get { return clickbuttons; }
    }

    public int towerIndex;
    public int towercost;
    void Start()
    {
        //moveText = GameObject.Find("Movetext").GetComponent<MoveText>();
        gameUI = GameObject.Find("inGameEvent").GetComponent<InGameUI>();

        clickbuttons = GetComponentsInChildren<Button>();
        missionManager = GameObject.Find("MissionManager").GetComponent<MissionManager>();

    }
    void Update()
    {
        if(isButtonDown)
        {
            gameUI.buttonDownTime += Time.deltaTime;
            gameUI.UpdateLoadingBar();
        }
        else
        {
            gameUI.buttonDownTime = 0;
            gameUI.UpdateLoadingBar();
        }
    }
    public void OnPointerDown(int index)
    {
        isButtonDown = true;
        gameUI.selectedBar = index;
    }

    public void OnPointerUp(int index)
    {
        isButtonDown = false;
        if(gameUI.buttonDownTime > gameUI.holdTimeThreshold)
        {
            if(index < 10)
            {
                gameUI.installTower(index);
                gameUI.player.CreateTower((Towers)index -1);
                switch (index)
                {
                    case 1:
                        towercost = -50;
                        break;
                    case 2:
                        towercost = -100;
                        break;
                    case 3:
                        towercost = -100;
                        break;
                }
            }
            else if(index == 11)
            {
                gameUI.repairTower();
                
            }
            else if(index == 12)
            {
                gameUI.cellTower();
                gameUI.player.RemoveTower();
            }
            
        }
        
        gameUI.ResetLoadingBar(index);
        //moveText.MoveTextOnEnergyChange(towercost);

    }

    

    
    

    public void pressRepair()
    {
        //��ֹ� �ı�
    }

    public void pressCell()
    {
        //Ÿ�� ȸ��
    }

    public void pressSkill(int index)
    {
        switch(index)
        {
            case 1:
                //����
                break;
            case 2:
                //�ٸ�����Ʈ ��ġ
                break;
            case 3:
                //��ź ��ġ
                break;
        }
    }



    public void pressPause()
    {
        gameUI.Pausebox.SetActive(true);

        gameUI.pauseGame(0);

        for(int i = 0; i < clickbuttons.Length; i++)
        {
            clickbuttons[i].interactable = false;
        }
        
    }

    public void pressResult(int index)
    {
        switch(index)
        {
            case 0:
                resetMissions();
                LoadSceneManager.LoadScene("GameLobby");
                break;
            case 1:
                resetMissions();
                break;
        }
    }
    public void PauseMenu(int index)
    {
        
        switch (index)
        {
            case 1:
                Time.timeScale = 1;
                resetMissions();
                LoadSceneManager.LoadScene("DesingDevelop");
                //�����
                break;
            case 2:
                gameUI.Pausebox.SetActive(false);
                gameUI.pauseGame(1);
                for (int i = 0; i < clickbuttons.Length; i++)
                {
                    clickbuttons[i].interactable = true;
                }
                break;
            case 3:
                Time.timeScale = 1;
                resetMissions();
                LoadSceneManager.LoadScene("GameLobby");
                break;
        }

    }

    private void resetMissions()
    {
        for (int i = 0; i < 3; i++)
        {
            //missionManager.stageMissions[0, i] = false;
        }
    }

}