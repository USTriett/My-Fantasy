using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private OnOutOfStateEventSO _onOutOfStateEventSO;

    [SerializeField]
    private OnWinningEventSO _onWinningEventSO;

    [SerializeField]
    private PlayerController _playerController;

    private Animator _animator;

    // private bool _isPlayerRotate;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _onOutOfStateEventSO?.AddOnOutOfStateAction(SetActiveSelf);
        _onWinningEventSO?.AddAction(MoveOut);
        // _playerController.RotateToGame(gameObject);
        // _isPlayerRotate = false;
    }

    private void MoveOut()
    {
        _animator?.SetBool("Move", true);
    }

    private void OnDisable()
    {
        _onOutOfStateEventSO?.RemoveOutOfStateAction(SetActiveSelf);
        _onWinningEventSO?.RemoveAction(MoveOut);
    }

    public void SetActiveSelf()
    {
        Debug.Log("Set Active: " + !gameObject.activeSelf);

        gameObject.SetActive(!gameObject.activeSelf);
        // _playerController.RotateToGame(gameObject);
    }
}
