using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class DogBaseStateMachine : MonoBehaviour
{
    [SerializeField]
    private DogAbstractSatesSO[] _dogAbstractSatesSOs;

    [SerializeField]
    private OnPlayerDetectedSO _onPlayerDetectedSO;

    [SerializeField]
    private OnPlayerDetectedSO _onAttackReadySO;

    private GameObject _weapon;

    private Dictionary<string, DogBaseState> _stateDic;
    private DogBaseState _initialState;

    private Animator _animator;

    private Rigidbody _rigidbody;

    public bool isChanged;
    public string nextState;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        Init();
    }

    private void OnEnable()
    {
        _onPlayerDetectedSO.AddAction(Chase);
        _onAttackReadySO.AddAction(Attack);
    }

    private void OnDisable()
    {
        _onPlayerDetectedSO.RemoveAction(Chase);
        _onAttackReadySO.RemoveAction(Attack);
    }

    private void Init()
    {
        _weapon = GetWeapon();
        isChanged = false;
        _stateDic = new Dictionary<string, DogBaseState>();
        for (int i = 0; i < _dogAbstractSatesSOs.Length; i++)
        {
            _stateDic[_dogAbstractSatesSOs[i].StateName.ToLower()] = _dogAbstractSatesSOs[i]
                .GetState();
        }
        _initialState = _stateDic["idle"];
        CurrentState = _initialState;
    }

    private GameObject GetWeapon()
    {
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            if (transform.GetChild(i).gameObject.CompareTag("Weapon"))
            {
                return transform.GetChild(i).gameObject;
            }
        }
        return null;
    }

    public DogBaseState CurrentState { get; set; }

    private void Update()
    {
        if (isChanged)
        {
            isChanged = false;
            // Debug.LogWarning("currentState " + CurrentState);
            CurrentState.OnExit(_animator, _rigidbody);
            nextState = CurrentState.DoChange(nextState);

            CurrentState = _stateDic.GetValueOrDefault(nextState);
            CurrentState.OnInit();
            CurrentState.OnEnter(_animator, _rigidbody);
        }

        if (_elapsedTime > 0)
        {
            _elapsedTime -= Time.deltaTime;
        }
    }

    private void Chase()
    {
        nextState = "chase";
        isChanged = true;
    }

    [SerializeField]
    private float _attackCooldown = 1.5f;

    public float AttackCoolDown => _attackCooldown;
    private float _elapsedTime = 0f;

    private void Attack()
    {
        if (_elapsedTime <= 0)
        {
            _elapsedTime = _attackCooldown;
            nextState = "attack";
            isChanged = true;
        }
    }
}
