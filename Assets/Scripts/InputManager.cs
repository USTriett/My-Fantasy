using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

[DefaultExecutionOrder(-1)]
public class InputManager : SingletonPersitent<InputManager>
{
    // public delegate void StartTouchEvent(Vector2 position);
    // public event StartTouchEvent OnStartTouch;

    public delegate void HoldingEvent(Vector2 position);
    public event HoldingEvent OnHolding;

    public delegate void DraggingEvent(Vector2 position);
    public event DraggingEvent OnDragging;

    public delegate void LookingEvent(Vector2 position);
    public event LookingEvent OnLooking;
    public delegate void AttackEvent();
    public event AttackEvent OnAttack;

    // public delegate void PuzzleBlockTouch();
    // public event PuzzleBlockTouch OnTouch;

    Player playerInputControl;

    protected override void Awake()
    {
        base.Awake();
        playerInputControl = new Player();
    }

    private void Start()
    {
        // playerInputControl.PlayerActions.Move.started += ctx => StartTouch(ctx);
        playerInputControl.PlayerActions.Move.performed += ctx => Draging(ctx);
        playerInputControl.PlayerActions.Look.performed += ctx => Looking(ctx);
        playerInputControl.PlayerActions.Attack.performed += ctx => Attacking();
        playerInputControl.Enable();
    }

    public void Attacking()
    {
        Debug.Log("Attack");

        OnAttack?.Invoke();
    }

    public void Looking(InputAction.CallbackContext ctx)
    {
        OnLooking?.Invoke(ctx.ReadValue<Vector2>());
    }

    public void Draging(InputAction.CallbackContext ctx)
    {
        OnDragging?.Invoke(ctx.ReadValue<Vector2>());
    }

    public void Holding(InputAction.CallbackContext context)
    {
        OnHolding?.Invoke(context.ReadValue<Vector2>());
    }
}
