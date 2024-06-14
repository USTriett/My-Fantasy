using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePooling : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    List<GameObject> preFabs;
    List<MiniGame> _games;
    private Dictionary<string, MiniGame> _gamesDict;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        SpawGames();
    }

    private void SpawGames()
    {
        int num = preFabs.Count;
        _games = new List<MiniGame>();
        _gamesDict = new Dictionary<string, MiniGame>();

        for (int i = 0; i < num; i++)
        {
            GameObject game = Instantiate(preFabs[i], transform);
            _games.Add(game.GetComponent<MiniGame>());

            game.name = preFabs[i].name;

            _gamesDict.Add(game.name, _games[i]);
            game.GetComponent<MiniGame>().DeactivateGame();
        }
    }

    public void Activate(string name)
    {
        bool hasValue = _gamesDict.TryGetValue(name, out MiniGame game);
        if (hasValue)
        {
            game.ActivateGame();
        }
        else
        {
            Debug.Log("Game not found");
        }
    }
}
