using System;
using System.Collections;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance;

    public GameState state;
    public static event Action<GameState> OnGameStateChanged;
    public PlayerController Player;
    public EnemyController Enemy;

    private void Awake()
    {
        if (Instance != null && Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        UpdateGameState(GameState.StartMenu);
    }

    public void RegisterPlayer(PlayerController player)
    {
        Player = player;
    }

    public void RegisterEnemy(EnemyController enemy)
    {
        Enemy = enemy;
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
