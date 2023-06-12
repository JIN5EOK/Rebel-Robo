using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Player player;
    
    public GameObject Pausebox;


    public TextMeshProUGUI EnergyText;
    public GameObject WaveText;

    public TextMeshProUGUI countText;
    private float timer = 0f;
    private int count = 3;
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

    private bool Ispause;

    public int textint = 0;

    private void Start()
    {
        countText.text = "3";

        
        InvokeRepeating(nameof(UpdateCountText), 1f, 1f);
    }
    private void UpdateCountText()
    {
        if (timer < 2f)
        {
            count--;
            countText.text = count.ToString();
            timer++;
        }
        else
        {
            countText.text = "";
            CancelInvoke(nameof(UpdateCountText));
        }
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

    public void pauseGame(int index)
    {
        switch(index)
        {
            case 0:
                Time.timeScale = 0;
                Ispause = true;
                return;
            case 1:
                Time.timeScale = 1;
                Ispause = false;
                return;
        }
        
       
    }

}