using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : Singleton<PlayerScore>
{
  private float score = 0;
  public float Score => score;

  private float distanceTravelled = 0;
  public float DistanceTravelled => distanceTravelled;

  private void LateUpdate() {
    if (GameStateManager.Instance.currentState != GameState.Play)
      return;

  }
}
