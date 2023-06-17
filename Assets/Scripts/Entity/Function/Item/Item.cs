using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class Item : Entity
{
    protected Player player;
    protected Action GetItemAction;

    [SerializeField] Sfxs getSound;
    protected abstract void GetItem();

    public void Awake()
    {
        GetItemAction = GetItem;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (other.TryGetComponent(out player) && GetItemAction != null)
            {
                AudioManager.Instance.PlaySfx(getSound);
                GetItemAction.Invoke();
                Destroyed();
            }
        }
    }
}
