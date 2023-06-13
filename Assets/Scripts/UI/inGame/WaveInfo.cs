using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WaveInfo : MonoBehaviour
{
    [SerializeField] private WaveSystem waveSystem;
    [SerializeField] private PlayerHQ playerHQ;
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI curEnemyCntText;
    [SerializeField] private TextMeshProUGUI maxEnemyCntText;

    [SerializeField] private MoveText moveText;
    [SerializeField] private TextMeshProUGUI curWaveText;
    [SerializeField] private TextMeshProUGUI maxWaveText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI energyText;
    public void OnEnable()
    {
        waveSystem.ChangeWaveCnt += (n) => curWaveText.text = n.ToString();
        waveSystem.ChangeMaxWaveCnt += (n) => maxWaveText.text = n.ToString();
        waveSystem.ChangeCurEnemyCnt += (n) => curEnemyCntText.text = n.ToString();
        waveSystem.ChangeMaxEnemyCnt += (n) => maxEnemyCntText.text = n.ToString();
        playerHQ.OnHpChange += (n) => hpText.text = n.ToString();
        player.EnergyChangeAction += (n) => {
            int before = Int32.Parse(energyText.text);
            int after = n;
            energyText.text = n.ToString();
            if(Mathf.Abs(after - before) > 10)
                moveText.MoveTextOnEnergyChange(after - before);
        };
    }
    public void OnDisable()
    {
        waveSystem.ChangeWaveCnt -= (n) => curWaveText.text = n.ToString();
        waveSystem.ChangeMaxWaveCnt -= (n) => maxWaveText.text = n.ToString();
        waveSystem.ChangeCurEnemyCnt -= (n) => curEnemyCntText.text = n.ToString();
        waveSystem.ChangeMaxEnemyCnt -= (n) => maxEnemyCntText.text = n.ToString();
        playerHQ.OnHpChange -= (n) => hpText.text = n.ToString();
        player.EnergyChangeAction -= (n) =>
        {
            int before = Int32.Parse(energyText.text);
            int after = n;
            energyText.text = n.ToString();
            if(Mathf.Abs(after - before) > 10)
                moveText.MoveTextOnEnergyChange(after - before);
        };
    }
}
