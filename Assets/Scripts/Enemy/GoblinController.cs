using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class GoblinController : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;

    [SerializeField]
    private OnPlayerDetectedSO _onPlayerDetectedSO;

    [SerializeField]
    private OnPlayerDetectedSO _onReadyAttackSO;

    private AIPath _aiPath;

    // Start is called before the first frame update
    void Start()
    {
        _aiPath = GetComponent<AIPath>();
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

    // Update is called once per frame
    void Update()
    {
        ForwardToTarget();
    }

    private void ForwardToTarget()
    {
        Vector3 direction = (-transform.position + _target.transform.position).normalized;

        var newRotation = Quaternion.LookRotation(direction);
        var newRotationInEuler = newRotation.eulerAngles;
        newRotationInEuler.x = 0;
        newRotationInEuler.z = 0;

        transform.localRotation = Quaternion.Euler(newRotationInEuler);
    }
}
