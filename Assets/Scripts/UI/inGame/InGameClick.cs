using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameClick : MonoBehaviour
{

    InGameUI gameUI;

    private bool ispressTower = false;
    void Start()
    {
        
        gameUI = GameObject.Find("IngameUI").GetComponent<InGameUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pressAttack()
    {
        //???? ???
    }

    public void pressTower()
    {
        if(!ispressTower)
        {
            gameUI.Tower1.SetActive(true);
            gameUI.Tower2.SetActive(true);
            gameUI.Tower3.SetActive(true);
            gameUI.Tower4.SetActive(true);
            ispressTower = true;
        }
        else
        {
            gameUI.Tower1.SetActive(false);
            gameUI.Tower2.SetActive(false);
            gameUI.Tower3.SetActive(false);
            gameUI.Tower4.SetActive(false);
            ispressTower = false;
        }
        

    }
    public void installTower(int index)
    {
        switch(index)
        {
            case 1:
                //?????? ??? ???
                break;
            case 2:
                //??? ???
                break;
            case 3:
                //?????
              break;
            case 4:
                //????
              break;
        }
    }

    public void pressRepair()
    {
        //???? ?ı?
    }

    public void pressSkill(int index)
    {
        switch(index)
        {
            case 1:
                //????
                break;
            case 2:
                //???????? ???
                break;
            case 3:
                //??? ???
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
                //?????
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
