using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "PlayerStatSO",
    menuName = "ScriptableObjects/Player/PlayerStatSO",
    order = 0
)]
public class PlayerStatSO : ScriptableObject
{
    public int health;
    public float attack;
    public float speed;
    public float mage;
    public float attackDistance;
}
