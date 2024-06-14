using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveController : MonoBehaviour
{
    // Start is called before the first frame update
    //Player Attributes
    [SerializeField]
    private OnPlayingModeEventSO _onPlayingModeEventSO;

    [SerializeField]
    private OnOutOfStateEventSO _onOutOfStateEventSO;

    private void Awake()
    {
        _onPlayingModeEventSO.AddOnPlayingModeAction(SetActiveSelf);
        _onOutOfStateEventSO.AddOnOutOfStateAction(SetActiveSelf);
    }

    private void OnDestroy()
    {
        _onOutOfStateEventSO.RemoveOutOfStateAction(SetActiveSelf);
        _onPlayingModeEventSO.RemoveOnPlayingModeAction(SetActiveSelf);
    }

    public void SetActiveSelf()
    {
        Debug.Log("Set Active: " + !gameObject.activeSelf);
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
