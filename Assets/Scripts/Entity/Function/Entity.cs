using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
// By Jinseok Bae
/// <summary>
/// 플레이어, 타워, 적, 아군기지, 장애물 등 엔터티들이 상속받는 기본 클래스
/// </summary>
public abstract class Entity : MonoBehaviour
{
    private Action<Entity> disableActions;

    public Action<Entity> DisableActions
    {
        get
        {
            if (disableActions == null)
                disableActions += (e) => { };
            return disableActions;
        }
        set => disableActions = value;
    }
    private Action<Entity> enableActions;

    public Action<Entity> EnableActions
    {
        get
        {
            if (enableActions == null)
                enableActions += (e) => { };
            return enableActions;
        }
        set => enableActions = value;
    }
    public virtual void Destroyed()
    {
        Destroy(this.gameObject);
    }
    
    protected virtual void OnDisable()
    {
        DisableActions.Invoke(this);
    }
    protected virtual void OnEnable()
    {
        EnableActions.Invoke(this);
    }
}
