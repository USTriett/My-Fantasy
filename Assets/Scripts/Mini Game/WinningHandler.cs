using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WinningHandler : MonoBehaviour
{
    [SerializeField]
    private OnWinningEventSO _onWinningEventSO;

    [SerializeField]
    private OnNewQuestEventSO _onNewQuestEventSO;

    private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _onWinningEventSO.AddAction(OnWinning);
    }

    private void OnDestroy()
    {
        _onWinningEventSO.RemoveAction(OnWinning);
    }

    private async void OnWinning()
    {
        await ParticleSystemPlay();
        Debug.Log("Parcicle system stop play");
        _onNewQuestEventSO.Notify();
    }

    private async Task ParticleSystemPlay()
    {
        _particleSystem.Play();
        // Debug.Log("Parcicle system start play");
        while (_particleSystem.isPlaying)
        {
            await Task.Yield();
        }

        // _onNewQuestEventSO.Notify();
    }
}
