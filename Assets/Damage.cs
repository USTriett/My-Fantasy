using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            if (target.TryGetComponent<PlayerStat>(out PlayerStat stat))
            {
                stat.LoseHealth(2);
                gameObject.SetActive(false);
            }
        }
    }
}
