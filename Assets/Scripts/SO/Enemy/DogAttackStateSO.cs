using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DogAttackStateSO", menuName = "EnemySO/DogAttackStateSO", order = 0)]
public class DogAttackStateSO : DogAbstractSatesSO
{
    [SerializeField]
    private string[] _stateTransition;

    [SerializeField]
    private DogAttackState _dogAttackState = new();

    public override DogBaseState GetState()
    {
        RulesTransition.AddRules("attack", _stateTransition);
        // _dogAttackState.AddWeapon(_weapon);
        return _dogAttackState;
    }
}
