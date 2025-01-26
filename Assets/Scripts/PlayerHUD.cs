using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public void LateUpdate()
    {
      if (GameStateManager.Instance.currentState != GameState.Play)
        return;
        
      scoreText.text = PlayerScore.Instance.Score.ToString("F1") + "m";
    }
}
