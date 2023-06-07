using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : Entity
{
    protected bool isExecute;
    protected Player player;
    public virtual void Execute(Player _player, ref bool _isSuccese)
    {
        player = _player;
        isExecute = true;
    }
}
