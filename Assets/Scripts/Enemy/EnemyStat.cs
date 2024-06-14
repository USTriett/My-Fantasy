using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    [SerializeField]
    private int _health;

    [SerializeField]
    private int _attack;

    public int Attack => _attack;
    public int Health => _health;

    public void LoseHeath(int damage)
    {
        Debug.Log("Lose Health");
        _health -= damage;
        if (_health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
