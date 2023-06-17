using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    [SerializeField] private PlayerHQ playerHQ;
    [SerializeField] private WaveSystem waveSystem;

    public GameObject ResultWindow;
    private int checkedHP;
    private int checkedWave;

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
            Time.timeScale = 0;
            ResultWindow.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void ActivateResultWindow()
    {
        Debug.Log("클리어!");
        Time.timeScale = 0;
        ResultWindow.transform.GetChild(1).gameObject.SetActive(true);
    }
}
