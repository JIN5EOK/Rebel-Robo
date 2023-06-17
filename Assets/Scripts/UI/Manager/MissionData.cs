using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission
{
    public string Name { get; set; }
    public bool IsCleared { get; set; }
    public int StageNum { get; set; }

    public Mission(string name, bool isCleared, int stageNum)
    {
        Name = name;
        IsCleared = isCleared;
        StageNum = stageNum;
    }
}
public class QuestData
{
    private Dictionary<string, Mission> missions = new Dictionary<string, Mission>();

    public QuestData()
    {
        // Hero
        missions.Add("1-1", new Mission("스테이지 클리어", false, 1));
        missions.Add("1-2", new Mission("체력 50%이상 남기고 클리어", false, 1));
        missions.Add("1-3", new Mission("타워를 1번 이상 회수", false, 1));


    }
    public string GetMissionName(string missionName)
    {
        if (missions.ContainsKey(missionName))
        {
            return missions[missionName].Name;
        }
        else
        {
            throw new ArgumentException("Invalid mission");
        }
    }

    public bool IsMissionCleared(string missionName)
    {
        if (missions.ContainsKey(missionName))
        {
            return missions[missionName].IsCleared;
        }
        else
        {
            throw new ArgumentException("Invalid mission");
        }
    }

    public int GetMissionStageNum(string missionName)
    {
        if (missions.ContainsKey(missionName))
        {
            return missions[missionName].StageNum;
        }
        else
        {
            throw new ArgumentException("Invalid mission");
        }
    }
}
public class MissionData : MonoBehaviour
{
    QuestData questData;

    public static MissionData Instance;
    public string[,] missionName = new string[1, 3];
    public bool[,] clearedMission = new bool[1, 3];
    //public string[,] MissionArray = new string[5, 3];
    
    
    public string[,] MissionArray = { { "스테이지 클리어", "체력 50%이상 남기고 클리어", "무기를 이용해 적에게 30번 이상 공격" },
                                        { "스테이지 클리어", "체력 50%이상 남기고 클리어", "스킬 3번 이상 사용" },
                                         { "스테이지 클리어", "체력 50%이상 남기고 클리어", "무기를 이용해 적을 10마리 이상 처치" },
                                        { "스테이지 클리어", "체력 50%이상 남기고 클리어", "장애물을 3번 이상 제거" },
                                        { "스테이지 클리어", "체력 50%이상 남기고 클리어", "장애물을 파괴 하지 않기" }};
    
    
    
    public MissionData()
    {
        questData = new QuestData();

        missionName = new string[1, 3];
        missionName[0, 0] = questData.GetMissionName("1-1");
        missionName[0, 1] = questData.GetMissionName("1-2");
        missionName[0, 2] = questData.GetMissionName("1-3");

        clearedMission = new bool[1,3];
        clearedMission[0, 0] = questData.IsMissionCleared("1-1");
        clearedMission[0, 1] = questData.IsMissionCleared("1-2");
        clearedMission[0, 2] = questData.IsMissionCleared("1-3");


    }
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        
    }
   
}
