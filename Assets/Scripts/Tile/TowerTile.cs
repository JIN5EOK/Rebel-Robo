using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTile : Tile
{
    public override bool AddEntity(Entity _entity)
    {
        if (Entity != null)
            return false;

        if (_entity.GetType() == typeof(Obstacle) || _entity.GetType() == typeof(Tower))
        {
            base.AddEntity(_entity);
            return true;
        }
        else
            return false;
    }
}
