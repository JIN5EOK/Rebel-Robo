using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    [SerializeField] private PlayerHQ playerHQ;
    [SerializeField] private WaveSystem waveSystem;

    public GameObject ResultWindow;
    public int checkedHP;
    private int checkedWave;
    public Action OnActivateResultWindow;
    GameManager gameManager;
    SaveManager saveManager;
    MissionManager missionManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        missionManager = GameObject.Find("MissionManager").GetComponent<MissionManager>();
    }
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
            Debug.Log("클리어 실패");
            ResultWindow.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void ActivateResultWindow()
    {
        Debug.Log("클리어!");
        gameManager.coin += 4;
        ResultWindow.transform.GetChild(1).gameObject.SetActive(true);
        OnActivateResultWindow?.Invoke();
        saveManager.Save();
    }
}
