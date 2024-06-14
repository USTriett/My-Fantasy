using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private OnPlayerSO _onLoseHealthSO;

    [SerializeField]
    private OnPlayerSO _onPlayerDeath;
    private HealthController[] _controllers;

    private int _numHealth = 6;

    void Start()
    {
        _controllers = GetComponentsInChildren<HealthController>();
    }

    private void OnEnable()
    {
        _onLoseHealthSO.AddAction(Lose);
    }

    private void OnDisable()
    {
        _onLoseHealthSO.RemoveAction(Lose);
    }

    private void Lose()
    {
        try
        {
            _controllers[_numHealth-- - 1].Lose();
            if (_numHealth == 0)
            {
                Debug.Log("Player die");
                _onPlayerDeath.Notify();
            }
        }
        catch (IndexOutOfRangeException) { }
    }
}
