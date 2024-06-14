using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "MazeDataSO",
    menuName = "ScriptableObjects/Data/MazeDataSO",
    order = 0
)]
[Serializable]
public class MazeDataSO : ScriptableObject
{
    [SerializeField]
    private GameObject _cellPrefabs;

    [SerializeField]
    private int[][] _mazeMatrix;

    public int[][] MazeMatrix => _mazeMatrix;

    public int GetCell(int r, int c)
    {
        return _mazeMatrix[r][c];
    }

    public GameObject GetBlockPrefabs()
    {
        return _cellPrefabs;
    }
}
