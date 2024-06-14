using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "OnPlayerSO",
    menuName = "ScriptableObjects/Player/OnPlayerSO",
    order = 0
)]
public class OnPlayerSO : ScriptableObject
{
    private Action _action;

    public void AddAction(Action action)
    {
        _action += action;
    }

    public void RemoveAction(Action action)
    {
        _action -= action;
    }

    public void Notify()
    {
        _action?.Invoke();
    }
}
