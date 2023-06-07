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
        //��ֹ� �ı�
    }

    public void cellTower()
    {
        textint = 12;
        //Ÿ�� ȸ��
    }
    public void installTower(int index)
    {
        switch (index)
        {
            case 1:
                //�ӽŰ� Ÿ��
                textint = 1;
                break;
            case 2:
                //ȭ�� Ÿ��
                textint = 2;
                break;
            case 3:
                //�̻���
                textint = 3;
                break;
        }
    }

    public void UpdateLoadingBar()
    {
        // ��ư�� ���� �ð��� ���� ������ ������Ʈ
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
        // ������ �ʱ�ȭ
        
    }

}