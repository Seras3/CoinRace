using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private GameObject _player1, _player2;
    
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
        if ((State == GameState.PAUSE || State == GameState.PLAY)  
            && Input.GetKeyDown(SettingsManagerScript.Instance.PauseGame))
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
            case GameState.RESTART:
                HandleRestart();
                break;
            case GameState.PLAY:
                HandlePlay();
                break;
            case GameState.MENU:
                break;
            case GameState.END_ROUND:
                break;
            case GameState.END_GAME:
                HandleEndGame();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    public void RestartGame()
    {
        UpdateState(GameState.RESTART);
    }
    
    public void PlayGame()
    {
        UpdateState(GameState.PLAY);
    }

    public void PauseGame()
    {
        UpdateState(GameState.PAUSE);
    }
    
    public void BrowseMenu()
    {
        UpdateState(GameState.MENU);
    }
    
    public void EndGame(float delay=0)
    {
        StartCoroutine(EndGameWithDelay(delay));
    }
    
    private IEnumerator EndGameWithDelay(float time)
    {
        yield return new WaitForSeconds(time);
 
        UpdateState(GameState.END_GAME);
    }

    private void FreezeGame()
    {
        Time.timeScale = 0;
        _player1.GetComponent<PlayerRotation>().enabled = false;
        _player2.GetComponent<PlayerRotation>().enabled = false;
    }

    private void UnfreezeGame()
    {
        Time.timeScale = 1;
        _player1.GetComponent<PlayerRotation>().enabled = true;
        _player2.GetComponent<PlayerRotation>().enabled = true;
    }
    
    private void HandlePause()
    {
        FreezeGame();
        UIManagerScript.Instance.DisplayPauseScreen();
    }

    private void HandleRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    private void HandlePlay()
    {
        UnfreezeGame();
        UIManagerScript.Instance.HidePauseScreen();
    }

    private void HandleEndGame()
    {
        bool isPlayer1Dead = _player1.GetComponent<HealthScript>().IsDead;
        FreezeGame();
        UIManagerScript.Instance.DisplayFinishScreen(!isPlayer1Dead);
    }
}

public enum GameState
{
    PAUSE,
    RESTART,
    PLAY,
    MENU,
    END_ROUND,
    END_GAME
}
