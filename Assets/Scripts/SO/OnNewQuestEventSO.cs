using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "OnNewQuestEventSO",
    menuName = "ScriptableObjects/OnNewQuestEventSO",
    order = 0
)]
public class OnNewQuestEventSO : ScriptableObject
{
    private Action _onNewQuestEventAction;

    public void AddAction(Action action)
    {
        _onNewQuestEventAction += action;
    }

    public void RemoveAction(Action action)
    {
        _onNewQuestEventAction -= action;
    }

    public void Notify()
    {
        _onNewQuestEventAction?.Invoke();
    }
}
