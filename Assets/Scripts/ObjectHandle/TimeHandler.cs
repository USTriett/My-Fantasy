using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeHandler : MonoBehaviour
{
    [SerializeField]
    private ItemCollectedObserveSO _itemCollectedObserveSO;

    // Start is called before the first frame update
    void Start()
    {
        _itemCollectedObserveSO.AddAction(PauseTime);
    }

    void OnDestroy()
    {
        _itemCollectedObserveSO.Remove(PauseTime);
    }

    private void PauseTime(string obj)
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    public void ResumeTime()
    {
        Time.timeScale = 1;
    }
}
