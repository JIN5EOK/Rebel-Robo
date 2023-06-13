using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

// By Jinseok Bae
/// <summary>
/// 엔터티를 생성하는 팩토리의 추상 베이스 클래스
/// </summary>
public abstract class EntityFactory<T, M> : MonoSingleton<EntityFactory<T,M>> where T : Entity where M : Enum
{
    protected Dictionary<M, string> EntityAddresses { get; set; }
    public T Spawn(M _types, Vector3 _position, Quaternion _rotation)
    {
        return MakeInstance(_types, _position, _rotation);
    }
    
    public T Spawn(M _types, Tile _tile, Quaternion _rotation)
    {
        if (_tile.Entity == null)
        {
            T entity = MakeInstance(_types, _tile.transform.position, _rotation);
            _tile.AddEntity(entity);

            return entity;
        }
        else
        {
            return null;
        }
    }
    private T MakeInstance(M _types, Vector3 _position, Quaternion _rotation)
    {
        GameObject go = Addressables.InstantiateAsync(EntityAddresses[_types], _position, _rotation).WaitForCompletion();
        go.AddComponent<AddressableAutoRelease>();
        return go.GetComponent<T>();
    }
}