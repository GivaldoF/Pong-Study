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

    public event Action<GameState> OnStateChanged;
    
    private GameState _currentState;
    public GameState CurrentState => _currentState;
    
    public GameStateManager(GameState initialState)
    {
        _currentState = initialState;
    }
    
    public void ChangeState(GameState newState)
    {
        _currentState = newState;
        Debug.Log($"Game state changed to {_currentState}");

        OnStateChanged?.Invoke(_currentState);
    }
    
    
}
