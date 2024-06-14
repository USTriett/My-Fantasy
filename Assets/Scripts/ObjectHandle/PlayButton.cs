using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayButton : MonoBehaviour, IButtonHandle
{
    //SerializeField
    [SerializeField]
    private bool _interactable = true;

    [SerializeField]
    private OnInteractButtonClickSO _onInteractButtonClickSO;

    [SerializeField]
    private OnPlayingModeEventSO _onPlayingModeEventSO;

    [SerializeField]
    private GameObject _gamePool;

    [SerializeField]
    private GameObject _virtualCamera;

    [SerializeField]
    private OnOutOfStateEventSO _onOutOfStateEventSO;

    private Vector3 _positionHolder;

    //Refs
    private Transform _transform;
    private GameObject _playText;

    private Action _moving;

    public bool Interactable => _interactable;

    // Start is called before the first frame update
    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _transform = gameObject.transform;
        _playText = _transform.GetChild(0).gameObject;
    }

    private void OnEnable()
    {
        AddAction();
        _onInteractButtonClickSO.AddPlayButtonAction(OnClick);
        _onOutOfStateEventSO.AddOnOutOfStateAction(MakeCanPress);
    }

    private void MakeCanPress()
    {
        SetText("Play");
        _transform.position = Vector3.Lerp(_transform.position, _positionHolder, 2);
    }

    private void OnDisable()
    {
        _onOutOfStateEventSO.RemoveOutOfStateAction(MakeCanPress);
        _onInteractButtonClickSO.RemoveButtonAction(OnClick);
        RemoveAction();
    }

    public void AnimateClip()
    {
        SetText("Playing");
        // endPosition.z = 1;
        _positionHolder = new Vector3(
            _transform.position.x,
            _transform.position.y,
            _transform.position.z
        );
        Vector3 endPosition = _transform.position + Vector3.forward * 9 / 10;

        _transform.position = Vector3.Lerp(_transform.position, endPosition, 2);
    }

    private void SetText(string v)
    {
        _playText.GetComponent<TextMeshPro>().text = v;
    }

    public void OnClick()
    {
        if (!_gamePool.TryGetComponent<GamePooling>(out var gamePooling))
        {
            Debug.Log("Game Pooling not found");
            return;
        }
        gamePooling.Activate("Puzzle");
        _virtualCamera.SetActive(true);

        _interactable = false;

        _moving?.Invoke();

        _onPlayingModeEventSO.EnterPlayingMode(OnPlayingModeEventSO.OnPlayingMode.Puzzle);
    }

    public void AddAction()
    {
        _moving += AnimateClip;
    }

    public void RemoveAction()
    {
        _moving -= AnimateClip;
    }
}
