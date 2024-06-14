using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeWinningHandle : MonoBehaviour
{
    [SerializeField]
    private GameObject _maze;

    void OnTriggerEnter(Collider other) { 
        if(_maze.TryGetComponent<Maze>(out Maze maze)){
            maze.Win();
        }
    }
}
