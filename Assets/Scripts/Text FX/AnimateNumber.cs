using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class AnimateNumber : MonoBehaviour
{

  [Header("Animate Number Settings")]

  [SerializeField] private float duration;

  private string text;

  private void StartAnimateFloatText() {
    StartCoroutine(AnimateFloatText(0, 1));
  }

  private IEnumerator AnimateFloatText(float startValue, float endValue)
  {
      float elapsedTime = 0f;
      float currentValue = startValue;
      
      while (elapsedTime < duration)
      {
          elapsedTime += Time.deltaTime;
          currentValue = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
          text = currentValue.ToString("F1");  // One decimal place
          yield return null;
      }
      
      text = endValue.ToString("F1");
  }
}
