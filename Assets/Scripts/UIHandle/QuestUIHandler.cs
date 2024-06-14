using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUIHandler : MonoBehaviour
{
    [SerializeField]
    private OnNewQuestEventSO _onNewQuestEventSO;

    private void OnEnable()
    {
        _onNewQuestEventSO.AddAction(Popup);
    }

    private void OnDisable()
    {
        _onNewQuestEventSO.RemoveAction(Popup);
    }

    private void Popup()
    {
        int childCount = gameObject.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void Close()
    {
        int childCount = gameObject.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
