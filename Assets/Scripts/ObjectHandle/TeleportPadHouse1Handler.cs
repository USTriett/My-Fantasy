using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TeleportPadHouse1Handler : MonoBehaviour
{
    [SerializeField]
    private OnWinningEventSO _onWinningEventSO;

    [SerializeField]
    private GameObject _destinitionTelePad;

    [SerializeField]
    VideoPlayerController _videoController;
    private ParticleSystem _particleSystem;

    private bool _isWinning = false;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isWinning && other.gameObject.tag == "Player")
        {
            DoTeleport(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_isWinning && other.gameObject.tag == "Player")
        {
            DoTeleport(other.gameObject);
        }
    }

    private void DoTeleport(GameObject player)
    {
        _videoController.PlayVideo();

        player.TryGetComponent<PlayerController>(out PlayerController controller);
        controller.MovePosition(_destinitionTelePad.transform.position);

        // controller.Pause();
    }

    private void OnEnable()
    {
        _onWinningEventSO.AddAction(HandleParticle);
    }

    private void OnDisable()
    {
        _onWinningEventSO.RemoveAction(HandleParticle);
    }

    private void HandleParticle()
    {
        ParticleSystemPlay();
        _isWinning = true;
    }

    private void ParticleSystemPlay()
    {
        _particleSystem?.Play();
    }
}
