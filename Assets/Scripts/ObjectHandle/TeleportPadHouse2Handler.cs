using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPadHouse2Handler : MonoBehaviour
{
    [SerializeField]
    private GamePooling _gamePooling;

    [SerializeField]
    private DoorHandler _doorHandler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            _gamePooling.Activate("Maze");
            _doorHandler.PlayParticleSystem();
        }
    }
}
