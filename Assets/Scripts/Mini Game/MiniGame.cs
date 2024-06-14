using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MiniGame : MonoBehaviour
{
    private string _name;

    protected bool isWin;

    protected bool isPlaying;

    // private Data data;

    public string Name
    {
        get { return _name; }
    }

    protected void Initialize(string name)
    {
        _name = name;
        isWin = false;
    }

    protected abstract void LoadData();

    public void ActivateGame()
    {
        gameObject.SetActive(true);
    }

    public void DeactivateGame()
    {
        gameObject.SetActive(false);
    }
}
