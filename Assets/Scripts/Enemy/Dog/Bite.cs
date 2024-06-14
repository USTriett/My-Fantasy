using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bite : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;

    [SerializeField]
    private OnPlayerDetectedSO _onReadyAttackSO;

    // private int count = 0;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == _target)
        {
            _onReadyAttackSO.Notify();
        }
    }
}
