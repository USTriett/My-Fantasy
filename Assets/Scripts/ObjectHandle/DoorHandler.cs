using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorHandler : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private PlayerController _playerController3D;

    [SerializeField]
    private GameObject _player2D;

    [SerializeField]
    private CameraController[] _cameraControllers;

    [SerializeField]
    private GameObject[] _camerasTransitions;

    private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    public void PlayParticleSystem()
    {
        _particleSystem.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player")
        {
            return;
        }
        _particleSystem.Stop();
        HandleCamera();
        BlockCharacterController();
        //wait 2s
        StartCoroutine(WaitAndChangeToPlayer2D());
    }

    private void UnblockCharacterController()
    {
        PlayerController controller = _player2D.GetComponent<PlayerController>();
        controller.Resume();
    }

    private void PushPlayerOutOfPipe()
    {
        Vector3 endPos = _player2D.transform.position + new Vector3(0.7f, 0, 0);
        _player2D
            .transform.DOMove(endPos, 0.5f) // Move the player in 0.5 seconds
            .OnComplete(() =>
            {
                UnblockCharacterController();
            })
            .Play();
    }

    private IEnumerator WaitAndChangeToPlayer2D()
    {
        yield return new WaitForSeconds(2f);
        ChangeToPlayer2D();
        PushPlayerOutOfPipe();
    }

    private void BlockCharacterController()
    {
        PlayerController controller = _player2D.GetComponent<PlayerController>();
        controller.Pause();
    }

    private void ChangeToPlayer2D()
    {
        _player2D.SetActive(true);

        _playerController3D.Pause();
        // Vector3 currentPos = _player2D.transform.position;
        // currentPos.z =
        // _player2D.transform.position = cu

        _player2D.TryGetComponent<PlayerController>(out PlayerController playerController);
        playerController.enabled = true;
        _player2D.TryGetComponent<PlayerInput>(out PlayerInput playerInput);
        playerInput.enabled = true;
    }

    private void HandleCamera()
    {
        foreach (CameraController cam in _cameraControllers)
            cam.SetActiveSelf();
    }
}
