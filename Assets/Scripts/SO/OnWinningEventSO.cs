using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "OnWinningEventSO",
    menuName = "ScriptableObjects/OnWinningEventSO",
    order = 0
)]
public class OnWinningEventSO : ScriptableObject
{
    private Action _onWinningEventAction;

    public void AddAction(Action action)
    {
        _onWinningEventAction += action;
    }

    public void RemoveAction(Action action)
    {
        _onWinningEventAction -= action;
    }

    public void Notify()
    {
        _onWinningEventAction?.Invoke();
    }
}
