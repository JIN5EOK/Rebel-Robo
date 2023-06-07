using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyClick : MonoBehaviour
{
    LobbyEvent lobbyEvent;
    GameManager gameManager;
    SaveManager saveManager;
    ProductData productData;
    // Start is called before the first frame update
    void Start()
    {
        lobbyEvent = GameObject.Find("LobbyEvent").GetComponent<LobbyEvent>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        saveManager = GameObject.Find("SaveManager").GetComponent <SaveManager>();
        productData = GameObject.Find("ProductData").GetComponent<ProductData>();
    }

    // Update is called once per frame

    public void GobeforeStage()
    {
        lobbyEvent.BeforeStage();
    }
    public void GonextStage()
    {
        lobbyEvent.NextStage();
    }

    public void Stage1Button()
    {
        gameManager.stageNumber = 1;
        if(!gameManager.stageMenuOn)
        {
            lobbyEvent.StageButtonClicked(gameManager.stageNumber);
        }
        
    }
    public void Stage2Button()
    {
        gameManager.stageNumber = 2;
        if (!gameManager.stageMenuOn)
        {
            lobbyEvent.StageButtonClicked(gameManager.stageNumber);
        }
    }

    public void Stage3Button()
    {
        gameManager.stageNumber = 3;
        if (!gameManager.stageMenuOn)
        {
            lobbyEvent.StageButtonClicked(gameManager.stageNumber);
        }
    }

    public void Stage4Button()
    {
        gameManager.stageNumber = 4;
        if (!gameManager.stageMenuOn)
        {
            lobbyEvent.StageButtonClicked(gameManager.stageNumber);
        }
    }

    public void Stage5Button()
    {
        gameManager.stageNumber = 5;
        if (!gameManager.stageMenuOn)
        {
            lobbyEvent.StageButtonClicked(gameManager.stageNumber);
        }
    }

    public void pickChamp1()
    {
        lobbyEvent.HeroboolArray[0] = true;
        lobbyEvent.HeroboolArray[1] = false;
        lobbyEvent.HeroboolArray[2] = false;
    }
    public void pickChamp2()
    {
        lobbyEvent.HeroboolArray[0] = false;
        lobbyEvent.HeroboolArray[1] = true;
        lobbyEvent.HeroboolArray[2] = false;
    }
    public void pickChamp3()
    {
        lobbyEvent.HeroboolArray[0] = false;
        lobbyEvent.HeroboolArray[1] = false;
        lobbyEvent.HeroboolArray[2] = true;
    }
    public void pickDiffi1()
    {
        lobbyEvent.DiffiboolArray[0] = true;
        lobbyEvent.DiffiboolArray[1] = false;
        lobbyEvent.DiffiboolArray[2] = false;
    }
    public void pickDiffi2()
    {
        lobbyEvent.DiffiboolArray[0] = false;
        lobbyEvent.DiffiboolArray[1] = true;
        lobbyEvent.DiffiboolArray[2] = false;
    }
    public void pickDiffi3()
    {
        lobbyEvent.DiffiboolArray[0] = false;
        lobbyEvent.DiffiboolArray[1] = false;
        lobbyEvent.DiffiboolArray[2] = true;
    }
    public void exitMenu()
    {
        lobbyEvent.ExitStageMenu();
    }

    public void startOption()
    {
        lobbyEvent.OptionClicked();
    }

    public void exitOption()
    {
        lobbyEvent.ExitOptionMenu();
    }

    public void startShop()
    {
        lobbyEvent.ShopClicked();
    }

    public void startGame()
    {
        lobbyEvent.loadGame();
    }

    public void resetData()
    {
        //PlayerPrefs.SetFloat("CoinAmount", 100f);
        gameManager.coin = 100;

        productData.buyedHero = new bool[3] { true, false, false };
        productData.buyedTower = new bool[6] { false, false, false, false, false, false };
        productData.buyedSkill = new bool[3] { false, false, false };
        productData.buyedEquip = new bool[2] { true, false};

        saveManager.Save();
        
    }
}
