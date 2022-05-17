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
    
    private static int Player1Wins { get; set; }
    private static int Player2Wins { get; set; }
    private bool IsPlayer1Winner { get; set; }

    public static void Init()
    {
        Player1Wins = 0;
        Player2Wins = 0;
    }
    
    private void Awake()
    {
        _instance = this;
    }
    
    private void Start()
    {
        UIManagerScript.Instance.DisplayRound(Player1Wins + Player2Wins + 1);
        if (Player1Wins > 0)
        {
            UIManagerScript.Instance.DisplayPlayer1Trophy();
        }

        if (Player2Wins > 0)
        {
            UIManagerScript.Instance.DisplayPlayer2Trophy();
        }
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
                HandleEndRound();
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

    public void EndRound(bool isPlayer1Winner, float delay = 0)
    {
        if (isPlayer1Winner)
        {
            Player1Wins++;
        }
        else
        {
            Player2Wins++;
        }
        StartCoroutine(EndRoundWithDelay(delay));
    }
    
    public void EndGame()
    {
        UpdateState(GameState.END_GAME);
    }

    private IEnumerator EndRoundWithDelay(float time)
    {
        yield return new WaitForSeconds(time);
 
        UpdateState(GameState.END_ROUND);
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
        Init();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    private void HandlePlay()
    {
        UnfreezeGame();
        UIManagerScript.Instance.HidePauseScreen();
    }

    private void HandleEndRound()
    {
        if (Player1Wins == SettingsManagerScript.Instance.MaxWins || Player2Wins == SettingsManagerScript.Instance.MaxWins)
        {
            IsPlayer1Winner = Player1Wins == SettingsManagerScript.Instance.MaxWins;
            EndGame();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
    private void HandleEndGame()
    {
        FreezeGame();
        UIManagerScript.Instance.DisplayFinishScreen(IsPlayer1Winner);
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
