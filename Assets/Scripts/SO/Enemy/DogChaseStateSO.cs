using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DogChaseStateSO", menuName = "EnemySO/DogChaseStateSO", order = 0)]
[Serializable]
public class DogChaseStateSO : DogAbstractSatesSO
{
    [SerializeField]
    private DogChaseState _dogChaseState = new();

    [SerializeField]
    private string[] _stateTransition;

    public override DogBaseState GetState()
    {
        for (int i = 0; i < _stateTransition.Length; i++)
        {
            _stateTransition[i] = _stateTransition[i].ToLower();
        }

        RulesTransition.AddRules(_stateName.ToLower(), _stateTransition);

        return _dogChaseState;
    }
}
