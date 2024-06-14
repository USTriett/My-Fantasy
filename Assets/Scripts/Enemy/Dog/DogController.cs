using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEditor;
using UnityEngine;

public class DogController : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;

    [SerializeField]
    private OnPlayerDetectedSO _onPlayerDetectedSO;

    [SerializeField]
    private OnPlayerDetectedSO _onReadyAttackSO;

    private GameObject _attackTrigger;
    private AIPath _aiPath;

    private void Start()
    {
        _aiPath = GetComponent<AIPath>();
        GetAttackTrigger();
    }

    private void GetAttackTrigger()
    {
        int count = gameObject.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            if (gameObject.transform.GetChild(i).name.ToLower() == "attacktrigger")
            {
                _attackTrigger = gameObject.transform.GetChild(i).gameObject;
            }
        }
    }

    private void OnEnable()
    {
        _onPlayerDetectedSO.AddAction(Move);
    }

    private void OnDisable()
    {
        _onPlayerDetectedSO.RemoveAction(Move);
    }

    private void Move()
    {
        _aiPath.canMove = true;
    }

    void Update()
    {
        if (_target == null)
            return;
        ForwardToTarget();
    }
    
    private void ForwardToTarget(){
        if (_target.transform.position.x - transform.position.x < 0)
        {
            if (transform.rotation.eulerAngles.y == 0)
                transform.Rotate(Vector3.up * 180);
        }
        else
        {
            if (transform.rotation.eulerAngles.y != 0)
                transform.Rotate(Vector3.up * -180);
        }
    }

    private void Stop()
    {
        _aiPath.canMove = false;
    }

    public void SpawnAttackTrigger()
    {
        _attackTrigger.SetActive(true);
    }

    public void DestroyAtttackTrigger()
    {
        _attackTrigger.SetActive(false);
    }
}
