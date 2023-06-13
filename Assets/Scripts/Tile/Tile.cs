using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public Entity Entity { get; protected set; }

    public virtual bool AddEntity(Entity _entity)
    {
        Entity = _entity;
        _entity.transform.position = this.transform.position + Vector3.up;
        _entity.transform.SetParent(this.transform);
        _entity.DisableActions += RemoveEntity;
        return true;
    }

    public void RemoveEntity(Entity _entity)
    {
        if (_entity == Entity)
        {
            Entity = null;    
        }
    }
}
