using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionData : MonoBehaviour
{

    public static MissionData Instance;

    LobbyEvent lobbyEvent;
    //public string[,] MissionArray = new string[5, 3];
    

    public string[,] MissionArray = { { "스테이지 클리어", "체력 50%이상 남기고 클리어", "타워를 1번 이상 회수" },
                                        { "스테이지 클리어", "체력 50%이상 남기고 클리어", "스킬 3번 이상 사용" },
                                         { "스테이지 클리어", "체력 50%이상 남기고 클리어", "무기를 이용해 적을 10마리 이상 처치" },
                                        { "스테이지 클리어", "체력 50%이상 남기고 클리어", "장애물을 3번 이상 제거" },
                                        { "스테이지 클리어", "체력 50%이상 남기고 클리어", "장애물을 파괴 하지 않기" }};

    //public bool[,] clearedMission = new bool[5, 3];
    public bool[,] clearedMission = { { false, false, false }, 
                                        { false, false, false }, 
                                        { false, false, false }, 
                                        { false, false, false }, 
                                        { false, false, false } };
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        lobbyEvent = GameObject.Find("LobbyEvent").GetComponent<LobbyEvent>();
    }
   
}
