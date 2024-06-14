using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ObjectDetection : MonoBehaviour
{
    // Start is called before the first frame updat
    // [SerializeField]
    // private GameObject _interactButton;

    [SerializeField]
    private ObjectDectectSO _objectDectectSO;

    [SerializeField]
    private GameObject player;
    private PlayerController playerController;
    private UnityAction<Vector3> sitdown;

    private UnityAction standup;
    private Vector3 chairPosition;
    private Action playGame;

    private EInteractableObject _interactableObject;

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();

        // AddOnClickListener();
    }

    void OnEnable()
    {
        sitdown += SitDown;
        standup += Standup;
    }

    void OnDisable()
    {
        sitdown -= SitDown;
        standup -= Standup;
    }

    private void Standup()
    {
        playerController.UnSit();
    }

    private void SitDown(Vector3 newPos)
    {
        playerController.DoSit(newPos);
    }

    private void FixedUpdate()
    {
        bool isHit = Physics.Raycast(
            transform.position,
            transform.TransformDirection(Vector3.forward),
            out RaycastHit hit,
            Mathf.Infinity,
            LayerMask.GetMask("Default")
        );

        if (isHit)
        {
            _interactableObject = GetInteractableObject(hit);
        }
        else
        {
            _interactableObject = EInteractableObject.None;
        }
        _objectDectectSO.Dectect(_interactableObject);
    }

    private EInteractableObject GetInteractableObject(RaycastHit hit)
    {
        switch (hit.collider.gameObject.tag)
        {
            case "Chair":
                return EInteractableObject.Chair;
            case "Button":
                return EInteractableObject.PlayButton;
            case "Game":
                return EInteractableObject.Game;
        }
        return EInteractableObject.None;
    }
}
