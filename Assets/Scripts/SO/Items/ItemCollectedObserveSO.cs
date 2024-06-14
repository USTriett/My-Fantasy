using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "ItemCollectedObserveSO",
    menuName = "ScriptableObjects/Items/ItemCollectedObserveSO",
    order = 0
)]
public class ItemCollectedObserveSO : ScriptableObject
{
    private Action<string> _action;

    public void Notify(string item)
    {
        _action?.Invoke(item);
    }

    public void AddAction(Action<string> a)
    {
        _action += a;
    }

    public void Remove(Action<string> a)
    {
        _action -= a;
    }
}
