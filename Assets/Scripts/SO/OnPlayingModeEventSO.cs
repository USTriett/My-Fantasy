using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    menuName = "ScriptableObjects/OnPlayingModeEventSO",
    fileName = "OnPlayingModeEventSO"
)]
public class OnPlayingModeEventSO : ScriptableObject
{
    public enum OnPlayingMode
    {
        None = 0,
        Puzzle = 1,
        //..
    }

    private Action _onPlayingModeAction;

    public void AddOnPlayingModeAction(Action action)
    {
        _onPlayingModeAction += action;
    }

    public void RemoveOnPlayingModeAction(Action action)
    {
        _onPlayingModeAction -= action;
    }

    public void EnterPlayingMode(OnPlayingMode mode)
    {
        _onPlayingModeAction?.Invoke();
    }
}
