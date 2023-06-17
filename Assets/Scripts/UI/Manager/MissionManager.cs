using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    [SerializeField] private PlayerHQ playerHQ;
    [SerializeField] private GameObject Stars;
    [SerializeField] private GameObject Missions;
    [SerializeField] private Image CoolImg;
    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject Dataobj;
    MissionData missionData;
    TextMeshProUGUI[] MissionsText;
    GameExit gameExit;

    Player player;
    public int skillCount = 0;
    InGameUI gameUI;

    public static MissionManager instance;
    public bool[,] stageMissions = new bool[1, 3];
    void Start()
    {

        gameExit = GameObject.Find("GameResult").GetComponent<GameExit>();
        missionData = Dataobj.GetComponent<MissionData>();

        gameExit.OnActivateResultWindow += printMissionResult;

        MissionsText = Missions.GetComponentsInChildren<TextMeshProUGUI>();

        gameUI = GameObject.Find("inGameEvent").GetComponent<InGameUI>();
        player = playerObj.GetComponent<Player>();
    }



    private void printMissionResult()
    {



        CheckMission1();
        CheckMission2();
        CheckMission3();

        for (int i = 0; i < 3; i++)
        {
            if (stageMissions[0, i])
            {
                Debug.Log(i);
                Stars.transform.GetChild(i).gameObject.SetActive(false);
                Stars.transform.GetChild(i + 3).gameObject.SetActive(true);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            MissionsText[i].text = missionData.missionName[0, i];

        }
        for (int i = 0; i < 3; i++)
        {
            missionData.clearedMission[0, i] = stageMissions[0, i];
        }
        if (missionData.clearedMission[0, 0] == true)
        {
            Debug.Log("¼º°ø");
        }
        //missionData.clearedMission = new bool[missionData.clearedMission.GetLength(0), missionData.clearedMission.GetLength(1)];
        //Array.Copy(stageMissions, 0, missionData.clearedMission, 0, stageMissions.GetLength(1));

    }
    private void CheckMission1()
    {
        stageMissions[0, 0] = true;
        MissionsText[0].fontStyle |= FontStyles.Strikethrough;
    }
    private void CheckMission2()
    {
        if (gameExit.checkedHP >= 50)
        {
            stageMissions[0, 1] = true;
            MissionsText[1].fontStyle |= FontStyles.Strikethrough;

        }
        else
        {
            stageMissions[0, 1] = false;
            MissionsText[1].fontStyle &= ~FontStyles.Strikethrough;

        }
    }

    private void CheckMission3()
    {

        if (player.AttackCount >= 30)
        {
            stageMissions[0, 2] = true;
            MissionsText[2].fontStyle |= FontStyles.Strikethrough;
        }
        else
        {
            stageMissions[0, 2] = false;
            MissionsText[2].fontStyle &= ~FontStyles.Strikethrough;
        }
    }
}
