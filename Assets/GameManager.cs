using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance;

    public GameState state;
    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        Instance = this;
    }

    
    public void UpdateGameState(GameState newState)
        {
            state = newState; 
            
            switch (newState)
            {
                case GameState.StartMenu:
                    break;
                case GameState.Play:
                    break;
                case GameState.GameOver:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }
            OnGameStateChanged?.Invoke(newState);
        }
    public enum GameState
    {
        StartMenu,
        Play,
        GameOver
    }
}
