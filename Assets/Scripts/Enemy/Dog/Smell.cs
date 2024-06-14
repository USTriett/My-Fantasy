using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smell : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private OnPlayerDetectedSO _onPlayerDetectSO;
    private bool _isPlayerDettected = false;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _isPlayerDettected = true;
            _onPlayerDetectSO.Notify();
        }
    }

    public bool IsPlayerDettected => _isPlayerDettected;
}
