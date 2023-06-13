using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// Written By Jinseok Bae
/// <summary>
/// 스킬, 탄환등 쿨타임 작동에 사용할 클래스
/// </summary>

public class CoolTime
{
    private Action<float> CoolTimeAction;
    private float curCoolTime;
    public float CurCoolTime
    {
        get => curCoolTime;
        set
        {
            if (IsComplete == true)
                return;
            if (value < 0) 
                IsComplete = true;
            curCoolTime = value;
            CoolTimeAction.Invoke(value / MaxCoolTime);
        }
    }
    public void AddCoolTimeAction(Action<float> _action)
    {
        CoolTimeAction += _action;
    }
    public void RemoveCoolTimeAction(Action<float> _action)
    {
        CoolTimeAction -= _action;
    }
    private float MaxCoolTime { get; set; }
    public bool IsComplete { get; private set; }
    public CoolTime(float _maxCoolTime)
    {
        IsComplete = false;
        MaxCoolTime = _maxCoolTime;
        curCoolTime = _maxCoolTime;
        CoolTimeAction += (float _value) => { };
    }
    public void Reset()
    {
        IsComplete = false;
        curCoolTime = MaxCoolTime;
    }
}
