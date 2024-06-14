using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutButtonhandler : MonoBehaviour
{
    [SerializeField]
    private OnOutOfStateEventSO _onOutOfStateEventSO;
    private Button _button;

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(_onOutOfStateEventSO.NotifyOnOutOfState);
    }
}
