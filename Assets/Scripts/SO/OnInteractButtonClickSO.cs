using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    menuName = "ScriptableObjects/OnInteractButtonClickSO",
    fileName = "OnInteractButtonClickSO"
)]
public class OnInteractButtonClickSO : ScriptableObject
{
    private Action _playerAction;
    private Action _targetAction;

    private Action _playButtonAction;

    public void AddPlayerAction(Action action)
    {
        _playerAction += action;
    }

    public void RemovePlayerAction(Action action)
    {
        _playerAction -= action;
    }

    public void AddTargetAction(Action action)
    {
        _targetAction += action;
    }

    public void RemoveTargetAction(Action action)
    {
        _targetAction -= action;
    }

    public void AddPlayButtonAction(Action action)
    {
        _playButtonAction += action;
    }

    public void RemoveButtonAction(Action action)
    {
        _playButtonAction -= action;
    }

    public void NotifyToPlayer()
    {
        _playerAction?.Invoke();
    }

    public void NotifyToTarget()
    {
        _targetAction?.Invoke();
    }

    public void NotifyToPlayButton()
    {
        _playButtonAction?.Invoke();
    }
}
