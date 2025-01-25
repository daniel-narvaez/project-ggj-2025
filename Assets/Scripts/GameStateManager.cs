using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Enum to represent the three game states
public enum GameState
{
  Start,
  Play,
  Pause,
  GameOver
}

public class GameStateManager : Singleton<GameStateManager>
{

    [Header("Game State Settings")]

    public GameState currentState = GameState.Start; // Default state is Start

    // UI elements (for controlling the game state)
    public GameObject startUI;
    public GameObject playUI;
    public GameObject pauseUI;
    public GameObject gameOverUI;

    private float holdTime = 0;
    public float startTimeThreshold;

    void Start()
    {
        // Set the initial UI state based on the default state
        UpdateUI();
    }

    void Update()
    {
        // Check for user input to change the game state
        if (currentState == GameState.Play)
        {
            // Check for Pause (Press P)
            if (Input.GetKeyDown(KeyCode.P))
            {
                SetGameState(GameState.Pause);
            }
        }
        else if (currentState == GameState.Pause)
        {
            // Check for Resume (Press P to resume play)
            if (Input.GetKeyDown(KeyCode.P))
            {
                SetGameState(GameState.Play);
            }
        }
        else if (currentState == GameState.Start)
        {
            // Start the game when pressing Enter
            if (Input.GetKey(KeyCode.Space))
            {
              holdTime += Time.deltaTime;

              if (holdTime >= startTimeThreshold)
                SetGameState(GameState.Play);
            } else {
              holdTime = 0;
            }
        }
    }

    // Method to set the current game state and handle state transitions
    public void SetGameState(GameState newState)
    {
        currentState = newState;
        UpdateUI();
    }

    // Update the UI based on the current state
    void UpdateUI()
    {
        // Hide all UI panels
        startUI?.SetActive(false);
        playUI?.SetActive(false);
        pauseUI?.SetActive(false);

        // Show the UI for the current game state
        switch (currentState)
        {
            case GameState.Start:
                startUI.SetActive(true);
                break;
            case GameState.Play:
                playUI.SetActive(true);
                break;
            case GameState.Pause:
                pauseUI.SetActive(true);
                break;
            case GameState.GameOver:
                gameOverUI.SetActive(true);
                break;
        }
    }
}
