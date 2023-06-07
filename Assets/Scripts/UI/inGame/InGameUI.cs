using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public GameObject Pausebox;


    public GameObject EnergyText;
    public GameObject WaveText;

    //public GameObject LoadingBar;
    public Image towerBar1;
    public Image towerBar2;
    public Image towerBar3;

    public Image repairBar;
    public Image cellBar;

    public int selectedBar;

    public float loadSpeed;
    float currentValue;

    public float buttonDownTime = 0f;
    public float holdTimeThreshold = 3f;

    public int textint = 0;
    void Start()
    {
        //Image LoadingBarimage = LoadingBar.transform.Find("LoadingBar").GetComponent<Image>();
    }

    // Update is called once per frame


    public void printEnergy()
    {

    }

    public void printWave()
    {

    }

    public void repairTower()
    {
        textint = 11;
        //장애물 파괴
    }

    public void cellTower()
    {
        textint = 12;
        //타워 회수
    }
    public void installTower(int index)
    {
        switch (index)
        {
            case 1:
                //머신건 타워
                textint = 1;
                break;
            case 2:
                //화염 타워
                textint = 2;
                break;
            case 3:
                //미사일
                textint = 3;
                break;
        }
    }

    public void UpdateLoadingBar()
    {
        // 버튼을 누른 시간에 따라 게이지 업데이트
        float fillAmount = Mathf.Clamp01(buttonDownTime / holdTimeThreshold);
        
        switch(selectedBar)
        {
            case 1:
                towerBar1.fillAmount = fillAmount;
                break;
            case 2:
                towerBar2.fillAmount = fillAmount;
                break;
            case 3:
                towerBar3.fillAmount = fillAmount;
                break;
            case 11:
                repairBar.fillAmount = fillAmount;
                break;
            case 12:
                cellBar.fillAmount = fillAmount;
                break;
        }
        
    }

    public void ResetLoadingBar(int index)
    {
        switch(index)
        {
            case 1:
                towerBar1.fillAmount = 0f;
                break;
            case 2:
                towerBar2.fillAmount = 0f;
                break;
            case 3:
                towerBar3.fillAmount = 0f;
                break;
            case 11:
                repairBar.fillAmount = 0f;
                break;
            case 12:
                cellBar.fillAmount = 0f;
                break;
        }
        // 게이지 초기화
        
    }

}