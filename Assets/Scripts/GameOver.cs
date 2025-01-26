using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI scoreText;

  public void LateUpdate() {
    if (GameStateManager.Instance.currentState == GameState.GameOver) 
    {
      scoreText.text = PlayerScore.Instance.Score.ToString("F1") + "m";
    }
  }
  public void RestartGame() => GameStateManager.Instance.RestartGame();
}
