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
    private List<Action<Entity>> disableActions = new List<Action<Entity>>();
    
    private List<Action<Entity>> destroyActions = new List<Action<Entity>>();
    public virtual void Destroyed()
    {
        Action<Entity> action;

        for (int i = destroyActions.Count - 1; i >= 0; i--)
        {
            action = destroyActions[i];
            action.Invoke(this);
            if(destroyActions.Contains(action))
                destroyActions.RemoveAt(i);
        }
        Destroy(this.gameObject);
    }

    protected virtual void OnEnable() { }

    protected virtual void OnDisable()
    {
        Action<Entity> action;

        for (int i = disableActions.Count - 1; i >= 0; i--)
        {
            action = disableActions[i];
            action.Invoke(this);
            if(disableActions.Contains(action))
                disableActions.RemoveAt(i);
        }
    }

    public void AddDisableAction(Action<Entity> _action)
    {
        if (disableActions.Contains(_action))
            return;
        
        disableActions.Add(_action);
    }
    public void RemoveDisableAction(Action<Entity> _action)
    {
        if (disableActions.Contains(_action) == false)
            return;
        
        disableActions.Remove(_action);
    }

    public void AddDestroyAction(Action<Entity> _action)
    {
        if (destroyActions.Contains(_action))
            return;
        
        destroyActions.Add(_action);
    }
    public void RemoveDestroyAction(Action<Entity> _action)
    {
        if (destroyActions.Contains(_action) == false)
            return;
        
        destroyActions.Remove(_action);
    }
}
