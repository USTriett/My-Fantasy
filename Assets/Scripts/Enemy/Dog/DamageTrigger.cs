using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.TryGetComponent<PlayerStat>(out PlayerStat playerStat))
            {
                int damage = transform.parent.GetComponent<EnemyStat>().Attack;
                playerStat.LoseHealth(damage);
            }
        }
        gameObject.SetActive(false);
    }
}
