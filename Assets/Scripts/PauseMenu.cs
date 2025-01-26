using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
  private GameState gameState => GameStateManager.Instance.currentState;

  public void TogglePauseState() {
    if (gameState == GameState.Pause)
      GameStateManager.Instance.SetGameState(GameState.Play);
    else if (gameState == GameState.Play)
      GameStateManager.Instance.SetGameState(GameState.Pause);
  }

  public void RestartGame() {
      GameStateManager.Instance.RestartGame();
  }
}
