using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDogState
{
    public void OnInit();
    public void OnEnter(Animator animator, Rigidbody rigidbody);
    public void Update();
    public void FixedUpdate();
    public void OnExit(Animator animator, Rigidbody rigidbody);
}

public abstract class DogBaseState : IDogState
{
    // protected RulesTransition trans;
    public abstract void FixedUpdate();

    public abstract void OnEnter(Animator animator, Rigidbody rigidbody);

    public abstract void OnExit(Animator animator, Rigidbody rigidbody);

    public abstract void OnInit();

    public abstract void Update();

    public abstract string DoChange(string nextState);
}
