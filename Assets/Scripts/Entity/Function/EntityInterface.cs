using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
// By Jinseok Bae
public interface IMoveable
{
    public void Move(Vector3 _dir);
}

public interface IDamageable
{
    public void Damaged(int _dmg);
}

public interface IDemolitionable
{
    public void Demolition(ref int _energy);
}
