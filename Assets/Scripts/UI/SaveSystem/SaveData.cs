using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    //여러가지 타입이 가능하지만, Dictionary는 안된다.
    [SerializeField] public int savedCoin;

    [SerializeField] public bool[] saveHero = new bool[3];
    [SerializeField] public bool[] saveTower = new bool[6];
    [SerializeField] public bool[] saveSkill = new bool[3];
    [SerializeField] public bool[] saveEquip = new bool[2];

    [SerializeField] public int LastClear;
    
    [SerializeField] public bool[,] saveMission = new bool[1,3];
    
    /*
    남은 코인

    구매한 펫
    구매한 타워
    구매한 스킬
    구매한 장비

    마지막 클리어 스테이지 (int)

    챕터 별 도전과제 (2차원 배열 bool[1][3])
    */
    //외부 Json 라이브러리가 아닌 JsonUtility를 쓰면 Vector3도 저장할 수 있다.
    

    //생성자
    public SaveData(int t_savedCoin, bool[] t_saveHero, bool[] t_saveTower, bool[] t_saveSkill, bool[] t_saveEquip, int t_LastClear, bool[,] t_saveMission)
    {
        savedCoin = t_savedCoin;
        //saveHero = t_saveHero;
        //saveTower = t_saveTower;
        //saveSkill = t_saveSkill;
        //saveEquip = t_saveEquip;
        //LastClear = t_LastClear;
        //saveMission = t_saveMission;

        // saveHero 배열 복사
        saveHero = new bool[t_saveHero.Length];
        Array.Copy(t_saveHero, 0, saveHero, 0, t_saveHero.Length);

        saveTower = new bool[t_saveTower.Length];
        Array.Copy(t_saveTower, 0, saveTower, 0, t_saveTower.Length);

        saveSkill = new bool[t_saveSkill.Length];
        Array.Copy(t_saveSkill, 0, saveSkill, 0, t_saveSkill.Length);

        saveEquip = new bool[t_saveEquip.Length];
        Array.Copy(t_saveEquip, 0, saveEquip, 0, t_saveEquip.Length);

        LastClear = t_LastClear;

        saveMission = new bool[t_saveMission.GetLength(0), t_saveMission.GetLength(1)];
        Array.Copy(t_saveMission, saveMission, t_saveMission.GetLength(0) * t_saveMission.GetLength(1));


    }
}
