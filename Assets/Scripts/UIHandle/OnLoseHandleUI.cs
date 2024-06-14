using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoseHandleUI : MonoBehaviour
{
    [SerializeField]
    private OnPlayerSO _onDeathSO;

    [SerializeField]
    private GameObject _loseNotificationUI;

    // Start is called before the first frame update

    private void ActiveLoseNotificaiton()
    {
        _loseNotificationUI.SetActive(true);
    }

    private void OnEnable()
    {
        _onDeathSO.AddAction(ActiveLoseNotificaiton);
    }

    private void OnDisable()
    {
        _onDeathSO.RemoveAction(ActiveLoseNotificaiton);
    }
}
