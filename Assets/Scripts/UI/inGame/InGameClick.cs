using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InGameClick : MonoBehaviour
{

    InGameUI gameUI;

     // ��ư�� ������ �־�� �ϴ� �ּ� �ð�
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
    }

    public void PauseMenu(int index)
    {
        switch(index)
        {
            case 1:
                //�����
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