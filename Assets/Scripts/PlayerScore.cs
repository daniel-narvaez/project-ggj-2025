using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : Singleton<PlayerScore>
{
  private GameState gameState => GameStateManager.Instance.currentState; 
  private float score = 0;
  public float Score => score;

  private float distanceTravelled = 0;
  public float DistanceTravelled => distanceTravelled;

  private void LateUpdate() {
    if (gameState == GameState.Start)
    {
      score = 0;
      distanceTravelled = 0;
      return;
    }
    else if (gameState != GameState.Play)
      return;

    distanceTravelled += Time.deltaTime / 4;
    score = Mathf.Round(distanceTravelled * 10f) / 10f;
  }
}
