using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DogChaseState : DogBaseState
{
    // private List<DogAction> _actions = new();
    [SerializeField]
    private DogTransition _transition;

    public override string DoChange(string state)
    {
        Dictionary<string, object> dict = new() { ["chase"] = state.ToLower() };
        string rs = _transition.MakeTransition(dict);
        // Debug.LogWarning("chase to: " + rs);
        return rs;
    }

    public override void FixedUpdate() { }

    public override void OnEnter(Animator animator, Rigidbody rigidbody)
    {
        animator.SetBool("IsMove", true);
    }

    public override void OnExit(Animator animator, Rigidbody rigidbody) { }

    public override void OnInit() { }

    public override void Update() { }
}
