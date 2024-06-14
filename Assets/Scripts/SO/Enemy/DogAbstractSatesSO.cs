using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public abstract class DogAbstractSatesSO : ScriptableObject
{
    [SerializeField]
    protected string _stateName;
    public string StateName => _stateName;

    public abstract DogBaseState GetState();
}
