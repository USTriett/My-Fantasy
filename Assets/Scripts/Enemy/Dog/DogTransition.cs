using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DogTransition : IDogTransition
{
    public string Decide(Dictionary<string, object> rules)
    {
        return RulesTransition.Transition(rules);
    }

    public string MakeTransition(Dictionary<string, object> rules)
    {
        return Decide(rules) ?? "idle";
    }
}
