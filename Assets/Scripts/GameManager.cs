using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // the game has 5 phases in any order
    // phase 1 - ball increase speed
    // phase 2 - paddle size down
    // phase 3 - more balls
    // phase 4 - paddles move a little bit horizontally for second or hit
    // phase 5 - trigger 2 or more phases in same time
    
    // score goal - 999
    // score goal/5 = 199,999
    // phase 1 - 0
    // phase 2 - 100 + random(50, 100)
    // phase 3 - 200 + random (-50, 50)
    // phase 4 - 300 + random (-50, 50)
    // phase 4 - 500 + random (-50, 50)
    
    [SerializeField] private Ball _ball;
    [SerializeField] private GameObject _mainMenuScreen;
    [SerializeField] private GameObject _gameOverScreen;
    
    void Start()
    {
        GameStateManager.Initialize(GameStateManager.GameState.MainMenu);
        GameStateManager.Instance.OnStateChanged += HandleStateChanged;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && GameStateManager.Instance.CurrentState == GameStateManager.GameState.MainMenu)
        {
            GameStateManager.Instance.ChangeState(GameStateManager.GameState.Playing);
        }
        else if (Input.anyKeyDown && GameStateManager.Instance.CurrentState == GameStateManager.GameState.GameOver)
        {
            GameStateManager.Instance.ChangeState(GameStateManager.GameState.MainMenu);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameStateManager.Instance.CurrentState == GameStateManager.GameState.Playing)
            {
                    GameStateManager.Instance.ChangeState(GameStateManager.GameState.Paused);
            }
            else if(GameStateManager.Instance.CurrentState == GameStateManager.GameState.Paused)
            {
                GameStateManager.Instance.ChangeState(GameStateManager.GameState.Playing);
            }
        }
    }

    void HandleStateChanged(GameStateManager.GameState newState)
    {
        switch (newState)
        {
            case GameStateManager.GameState.MainMenu:
                ShowMenuScreen();
                HideGameOverScreen();
                break;
            case GameStateManager.GameState.Playing:
                Time.timeScale = 1;
                HideMenuScreen();
                HideGameOverScreen();
                break;
            case GameStateManager.GameState.Paused:
                Time.timeScale = 0;
                ShowMenuScreen();
                HideGameOverScreen();
                break;
            case GameStateManager.GameState.GameOver:
                ShowGameOverScreen();
                break;
        }
    }
    
    void ShowGameOverScreen()
    {
        _gameOverScreen.SetActive(true);
    }

    void HideGameOverScreen()
    {
        _gameOverScreen.SetActive(false);
    }

    void ShowMenuScreen()
    {
        _mainMenuScreen.SetActive(true);
    }
    
    void HideMenuScreen()
    {
        _mainMenuScreen.SetActive(false);
    }
}
