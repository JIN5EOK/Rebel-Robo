using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    [SerializeField] private PlayerHQ playerHQ;
    [SerializeField] private WaveSystem waveSystem;
    [SerializeField] private MissionManager missionManager;

    public GameObject ResultWindow;
    public int checkedHP;
    private int checkedWave;
    public Action OnActivateResultWindow;

    private void OnEnable()
    {
        playerHQ.OnHpChange += UpdateCheckedHP;
        waveSystem.OnGameClear += ActivateResultWindow;
    }

    private void OnDisable()
    {
        playerHQ.OnHpChange -= UpdateCheckedHP;
        waveSystem.OnGameClear -= ActivateResultWindow;
    }

    private void UpdateCheckedHP(int currentHp)
    {
        checkedHP = currentHp;
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (checkedHP <= 0)
        {
            Debug.Log("Ŭ���� ����");
            Time.timeScale = 0;
            ResultWindow.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void ActivateResultWindow()
    {
        Debug.Log("Ŭ����!");
        Time.timeScale = 0;
        ResultWindow.transform.GetChild(1).gameObject.SetActive(true);
        OnActivateResultWindow?.Invoke();
    }
}
