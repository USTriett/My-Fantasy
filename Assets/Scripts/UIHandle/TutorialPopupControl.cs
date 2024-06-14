using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPopupControl : MonoBehaviour
{
    [SerializeField]
    ItemCollectedObserveSO _itemCollectedObserveSO;

    private void Start()
    {
        gameObject.SetActive(false);
        _itemCollectedObserveSO.AddAction(Popup);
    }

    void OnDestroy()
    {
        _itemCollectedObserveSO.Remove(Popup);
    }

    private void Popup(string obj)
    {
        gameObject.SetActive(true);
    }
}
