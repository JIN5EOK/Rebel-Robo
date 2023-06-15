using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField] private PlayerHQ playerHQ;
    [SerializeField] private GameObject Stars;
    [SerializeField] private GameObject Missions;
    MissionData missionData;
    TextMeshProUGUI[] MissionsText;
    GameExit gameExit;
    

    
    public static MissionManager instance;
    public bool[,] clearedMissions = new bool[1, 3];
    void Start()
    {
        
        gameExit = GameObject.Find("GameResult").GetComponent<GameExit>();
        missionData = GameObject.Find("MissionData").GetComponent<MissionData>();

        gameExit.OnActivateResultWindow += CheckMission;

        MissionsText = Missions.GetComponentsInChildren<TextMeshProUGUI>();

    }
    /*
    private void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            MissionsText[i].text = missionData.MissionArray[0, i];
        }
    }
    */
    private void CheckMission()
    {
        clearedMissions[0, 0] = true;
        MissionsText[0].fontStyle |= FontStyles.Strikethrough;

        if (gameExit.checkedHP >= 50)
        {
            clearedMissions[0, 1] = true;
            MissionsText[1].fontStyle |= FontStyles.Strikethrough;
        }
        else
        {
            clearedMissions[0, 1] = false;
            MissionsText[1].fontStyle &= ~FontStyles.Strikethrough;
        }


        /////////////////미션 판정///////////////////////////////////
        for(int i = 0; i < 3; i++)
        {
            if(clearedMissions[0, i])
            {
                Stars.transform.GetChild(i).gameObject.SetActive(false);
                Stars.transform.GetChild(i + 3).gameObject.SetActive(true);
            }
        }

        for(int i = 0; i < 3; i++)
        {
            MissionsText[i].text = missionData.MissionArray[0,i];
            
        }

        
        
    }
}
