using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InGameClick : MonoBehaviour
{

    InGameUI gameUI;

     // 버튼을 누르고 있어야 하는 최소 시간
    private bool isButtonDown = false;
    


    public int towerIndex;
    void Start()
    {
        
        gameUI = GameObject.Find("inGameEvent").GetComponent<InGameUI>();
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
        

    }

    

    
    

    public void pressRepair()
    {
        //장애물 파괴
    }

    public void pressCell()
    {
        //타워 회수
    }

    public void pressSkill(int index)
    {
        switch(index)
        {
            case 1:
                //버프
                break;
            case 2:
                //바리게이트 설치
                break;
            case 3:
                //폭탄 설치
                break;
        }
    }



    public void pressPause()
    {
        gameUI.Pausebox.SetActive(true);
    }

    public void PauseMenu(int index)
    {
        switch(index)
        {
            case 1:
                //재시작
                break;
            case 2:
                gameUI.Pausebox.SetActive(false);
                break;
            case 3:
                SceneManager.LoadScene("GameLobby");
                break;
        }
        
    }

}