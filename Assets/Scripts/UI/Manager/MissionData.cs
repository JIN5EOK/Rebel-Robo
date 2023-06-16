using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionData : MonoBehaviour
{

    public static MissionData Instance;

    LobbyEvent lobbyEvent;
    //public string[,] MissionArray = new string[5, 3];
    

    public string[,] MissionArray = { { "�������� Ŭ����", "ü�� 50%�̻� ����� Ŭ����", "Ÿ���� 1�� �̻� ȸ��" },
                                        { "�������� Ŭ����", "ü�� 50%�̻� ����� Ŭ����", "��ų 3�� �̻� ���" },
                                         { "�������� Ŭ����", "ü�� 50%�̻� ����� Ŭ����", "���⸦ �̿��� ���� 10���� �̻� óġ" },
                                        { "�������� Ŭ����", "ü�� 50%�̻� ����� Ŭ����", "��ֹ��� 3�� �̻� ����" },
                                        { "�������� Ŭ����", "ü�� 50%�̻� ����� Ŭ����", "��ֹ��� �ı� ���� �ʱ�" }};

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
