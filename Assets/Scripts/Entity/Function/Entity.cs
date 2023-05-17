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
    
    [SerializeField]
    private List<Action<Entity>> disableActions;

    private List<Action<Entity>> DisableActions
    {
        get
        {
            if (disableActions == null)
                disableActions = new List<Action<Entity>>();
            return disableActions;
        }
    }
    
    public virtual void Destroyed()
    {
        Destroy(this.gameObject);
    }
    
    protected virtual void OnDisable()
    {
        Action<Entity> action;

        for (int i = DisableActions.Count - 1; i >= 0; i--)
        {
            action = DisableActions[i];
            action.Invoke(this);
            if(DisableActions.Contains(action))
                DisableActions.RemoveAt(i);
        }
    }

    public void AddDisableAction(Action<Entity> _action)
    {
        if (DisableActions.Contains(_action))
            return;
        
        DisableActions.Add(_action);
    }
    public void RemoveDisableAction(Action<Entity> _action)
    {
        if (DisableActions.Contains(_action) == false)
            return;
        
        DisableActions.Remove(_action);
    }
    
}
