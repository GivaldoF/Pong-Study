using System;
using UnityEngine;

public class GameStateManager
{
    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }
    
    public static GameStateManager Instance { get; private set; }

    public event Action<GameState> OnStateChanged;
    
    private GameState _currentState;
    public GameState CurrentState => _currentState;
    
    public GameStateManager(GameState initialState)
    {
        _currentState = initialState;
    }
    
    public static void Initialize(GameState initialState)
    {
        Instance ??= new GameStateManager(initialState);
    }
    
    public void ChangeState(GameState newState)
    {
        _currentState = newState;
        OnStateChanged?.Invoke(_currentState);
    }
}
