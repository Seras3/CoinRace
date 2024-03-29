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
    
    public static int Player1Wins { get; private set; }
    public static int Player2Wins { get; private set; }
    
    private static bool _hasRoundEnded;
    private bool IsPlayer1Winner { get; set; }

    private bool HasFinishedGame { get; set; }
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

        IsPlayer1Winner = Player1Wins == SettingsManagerScript.Instance.MaxWins;
        HasFinishedGame = IsPlayer1Winner || Player2Wins == SettingsManagerScript.Instance.MaxWins;

        if (HasFinishedGame)
        {
            if (IsPlayer1Winner)
            {
                _player1.GetComponent<PlayerAnimation>().Win();
                _player2.GetComponent<PlayerAnimationDelegate>().DisableMovement();
            }
            else
            {
                _player1.GetComponent<PlayerAnimationDelegate>().DisableMovement();
                _player2.GetComponent<PlayerAnimation>().Win();
            }
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
        SoundManagerScript.Instance.GameMusicPause();
    }

    private void HandleRestart()
    {
        Init();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    private void HandlePlay()
    {
        SoundManagerScript.Instance.GameMusicPlay();
        UnfreezeGame();
        UIManagerScript.Instance.HidePauseScreen();

        if (_hasRoundEnded)
        {
            _hasRoundEnded = false;
            SoundManagerScript.Instance.StartRoundSoundPlay();
        }
    }

    private void HandleEndRound()
    {
        SoundManagerScript.Instance.GameMusicPause();
        if (HasFinishedGame)
        {
            SoundManagerScript.Instance.LoudCrowdSoundPlay();

            EndGame();
        }
        else
        {
            _hasRoundEnded = true;
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
