using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : SingletonPersitent<PlayerStat>
{
    [SerializeField]
    private PlayerStatSO _playerStatDataSO;

    [SerializeField]
    private OnPlayerSO _onLoseHealthSO;

    private int _health;
    private float _attack;

    private float _attackDistance;
    public float AttackDistance => _attackDistance;
    public float Attack => _attack;

    void Start()
    {
        _health = _playerStatDataSO.health;
        _attack = _playerStatDataSO.attack;
        _attackDistance = _playerStatDataSO.attackDistance;
    }

    public void LoseHealth(int damage)
    {
        _onLoseHealthSO.Notify();
        _health -= damage;
    }
}
