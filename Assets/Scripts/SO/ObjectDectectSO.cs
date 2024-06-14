using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "ObjectDectectSO",
    menuName = "ScriptableObjects/ObjectDectectSO",
    order = 1
)]
public class ObjectDectectSO : ScriptableObject
{
    private Action<EInteractableObject> _foundInteractableObject;

    public void Dectect(EInteractableObject EInteractableObject)
    {
        _foundInteractableObject?.Invoke(EInteractableObject);
    }

    public void AddAction(Action<EInteractableObject> action)
    {
        _foundInteractableObject += action;
    }

    public void RemoveAction(Action<EInteractableObject> action)
    {
        _foundInteractableObject -= action;
    }
}
