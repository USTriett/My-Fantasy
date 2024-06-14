using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "OnOutOfStateEventSO",
    menuName = "ScriptableObjects/OnOutOfStateEventSO",
    order = 0
)]
public class OnOutOfStateEventSO : ScriptableObject
{
    [Tooltip("Observe Pattern for out of state like PlayingState, SittingState, RiddingState")]
    private Action _onOutOfStateAction;

    public void AddOnOutOfStateAction(Action action)
    {
        _onOutOfStateAction += action;
    }

    public void RemoveOutOfStateAction(Action action)
    {
        _onOutOfStateAction -= action;
    }

    public void NotifyOnOutOfState()
    {
        _onOutOfStateAction?.Invoke();
    }

    internal void AddAction(object blockPlaying)
    {
        throw new NotImplementedException();
    }

    internal void AddOnOutOfStateAction(object makeCanPress)
    {
        throw new NotImplementedException();
    }

    internal void RemoveOutOfStateAction(object makeCanPress)
    {
        throw new NotImplementedException();
    }
}
