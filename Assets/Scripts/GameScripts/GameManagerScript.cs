using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private static GameManagerScript _instance;

    public static GameManagerScript Instance
    {
        get
        {
            if (_instance is null)
            {
                print("GAME MANAGER is NULL");
            }

            return _instance;
        }
    }
    public GameState State { get; set; }

    private void Awake()
    {
        _instance = this;
    }
    
    private void Start()
    {
        PlayGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(Settings.pauseGame))
        {
            UpdateState(State == GameState.PAUSE ? GameState.PLAY : GameState.PAUSE);
        }
    }

    public void UpdateState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.PAUSE:
                HandlePause();
                break;
            case GameState.PLAY:
                HandlePlay();
                break;
            case GameState.END_ROUND:
                break;
            case GameState.END_GAME:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
   
    public void PlayGame()
    {
        UpdateState(GameState.PLAY);
    }
    
    private void HandlePause()
    {
        Time.timeScale = 0;
        GameObject.Find(ObjectNames.PLAYER_1).GetComponent<PlayerRotation>().enabled = false;
        GameObject.Find(ObjectNames.PLAYER_2).GetComponent<PlayerRotation>().enabled = false;
        UIManagerScript.Instance.DisplayPauseScreen();
    }

    private void HandlePlay()
    {
        Time.timeScale = 1;
        GameObject.Find(ObjectNames.PLAYER_1).GetComponent<PlayerRotation>().enabled = true;
        GameObject.Find(ObjectNames.PLAYER_2).GetComponent<PlayerRotation>().enabled = true;
        UIManagerScript.Instance.HidePauseScreen();
    }
}

public enum GameState
{
    PAUSE,
    PLAY,
    END_ROUND,
    END_GAME
}
