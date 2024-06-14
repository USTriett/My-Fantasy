using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Maze : MiniGame
{
    [SerializeField]
    private MazeDataSO _mazeDataSO;

    [SerializeField]
    private OnWinningEventSO _onWinningEventSO;

    [SerializeField]
    private OnPlayingModeEventSO _onPlayingModeEventSO;

    //Data Holder

    private bool _isWinning;

    protected override void LoadData()
    {
        // _mazeData = _mazeDataSO.MazeMatrix;
        // _rows = _mazeDataSO.MazeMatrix.Length;
        // _cols = _mazeDataSO.MazeMatrix[0].Length;
    }

    // Start is called before the first frame update
    private void Start()
    {
        LoadData();

        // BuildMaze();
    }

    private Action _selfDisable;

    private void OnEnable()
    {
        _selfDisable = () =>
        {
            SceneManager.LoadScene("Level 2");
        };
        _onWinningEventSO.AddAction(_selfDisable);
    }

    private void OnDisable()
    {
        _onWinningEventSO.RemoveAction(_selfDisable);
    }

    // Update is called once per frame
    private void Update() { }

    public void Win()
    {
        Debug.Log("Maze Winning");
        _onWinningEventSO.Notify();
    }
}
