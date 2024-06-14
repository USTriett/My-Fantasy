using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DogIdleState : DogBaseState
{
    // private static List<DogAction> _actions = new();

    [SerializeField]
    private DogTransition _transition;

    public override string DoChange(string rule)
    {
        Dictionary<string, object> dict = new() { ["idle"] = rule.ToLower() };
        string rs = _transition.MakeTransition(dict);
        // Debug.LogWarning("idle transto: " + rs);

        return rs;
        // OnExit(Animator animator, Rigidbody rigidbody);
    }

    public override void FixedUpdate() { }

    public override void OnEnter(Animator animator, Rigidbody rigidbody)
    {
        // foreach (var action in _actions)
        // {
        //     action.Execute();
        // }
    }

    public override void OnExit(Animator animator, Rigidbody rigidbody) { }

    public override void OnInit()
    {
        // _actions = new List<DogAction>();
    }

    public override void Update()
    {
        // _transition.MakeTransition()
    }
}
