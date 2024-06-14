using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    // [SerializeField]
    // private SkillInfoSO _skillInfoSO;

    private void OnParticleCollision(GameObject enemy)
    {
        Debug.Log("enemy: " + enemy.name);
        if (enemy.TryGetComponent<EnemyStat>(out EnemyStat stat))
        {
            stat.LoseHeath(2);
        }
    }
}
