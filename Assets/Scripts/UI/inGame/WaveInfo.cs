using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WaveInfo : MonoBehaviour
{
    [SerializeField] private WaveSystem waveSystem;

    [SerializeField] private TextMeshProUGUI curEnemyCntText;
    [SerializeField] private TextMeshProUGUI maxEnemyCntText;

    [SerializeField] private TextMeshProUGUI curWaveText;
    [SerializeField] private TextMeshProUGUI maxWaveText;
    public void Awake()
    {
        waveSystem.ChangeWaveCnt += (n) => curWaveText.text = n.ToString();
        waveSystem.ChangeMaxWaveCnt += (n) => maxWaveText.text = n.ToString();
        waveSystem.ChangeCurEnemyCnt += (n) => curEnemyCntText.text = n.ToString();
        waveSystem.ChangeMaxEnemyCnt += (n) => maxEnemyCntText.text = n.ToString();
    }
}
