using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class RulesTransition
{
    //load rule from json -> rule has a type of dict string -> string -> string ... -> bool
    private static Dictionary<string, object> _sRulesSet = new();

    public static void AddRules(string key, object val)
    {
        _sRulesSet.TryAdd(key, val);
    }

    public static void RemoveRules(Dictionary<string, object> oldRule) { }

    public static string Transition(Dictionary<string, object> rules)
    {
        // object dict = _sRulesSet;
        string originState = "";
        foreach (var key in rules.Keys)
        {
            originState = key;
            break;
        }

        rules.TryGetValue(originState, out object val);
        _sRulesSet.TryGetValue(originState, out object stateNames);
        try
        {
            if (((string[])stateNames).Contains((string)val))
            {
                return (string)val;
            }
        }
        catch (NullReferenceException e)
        {
            Debug.LogError(e);
            return originState;
        }

        return originState;
    }
}
