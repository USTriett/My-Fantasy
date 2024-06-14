using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DogIdleStatesSO", menuName = "EnemySO/DogIdleStateSO", order = 0)]
[Serializable]
public class DogIdleStateSO : DogAbstractSatesSO
{
    [SerializeField]
    private DogIdleState _dogIdleState;

    [SerializeField]
    private string[] _stateTransition;

    public override DogBaseState GetState()
    {
        for (int i = 0; i < _stateTransition.Length; i++)
        {
            _stateTransition[i] = _stateTransition[i].ToLower();
        }
        RulesTransition.AddRules(_stateName.ToLower(), _stateTransition);
        return _dogIdleState;
    }
}
