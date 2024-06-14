using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour
{
    [SerializeField]
    private ObjectDectectSO _objectDectectSO;

    [SerializeField]
    private OnInteractButtonClickSO _onInteractButtonClickSO;

    //Refs
    private Button _interactButton;

    private EInteractableObject _interactableObject;

    // Start is called before the first frame update



    private void Start() { }

    void OnEnable()
    {
        _interactButton = GetComponent<Button>();
        _interactButton.onClick.AddListener(OnClickHandle);
        _objectDectectSO.AddAction(InteractButtonAction);
    }

    private void OnDisable()
    {
        _interactButton.onClick.RemoveListener(OnClickHandle);

        _objectDectectSO.RemoveAction(InteractButtonAction);
    }

    private void InteractButtonAction(EInteractableObject eInteractableObject)
    {
        _interactableObject = eInteractableObject;
        if (eInteractableObject is EInteractableObject.None)
        {
            _interactButton.interactable = false;
        }
        else
        {
            _interactButton.interactable = true;
        }
        SetText(eInteractableObject);
    }

    private void SetText(EInteractableObject EInteractableObject)
    {
        switch (EInteractableObject)
        {
            case EInteractableObject.None:
                _interactButton.GetComponentInChildren<TextMeshProUGUI>().text = "";
                break;
            case EInteractableObject.PlayButton:
                _interactButton.GetComponentInChildren<TextMeshProUGUI>().text = "Press";
                break;
            case EInteractableObject.Chair:
                _interactButton.GetComponentInChildren<TextMeshProUGUI>().text = "Sit";
                break;
            case EInteractableObject.Game:
                _interactButton.GetComponentInChildren<TextMeshProUGUI>().text = "Play";
                break;
        }
    }

    private void OnClickHandle()
    {
        if (_interactableObject is EInteractableObject.PlayButton)
        {
            _onInteractButtonClickSO.NotifyToPlayButton();
        }
    }
}
