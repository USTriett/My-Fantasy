using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAction : IAction
{
    Action _action;

    public void AddAction(Action action)
    {
        _action = action;
    }

    public void Execute()
    {
        _action?.Invoke();
    }
}
