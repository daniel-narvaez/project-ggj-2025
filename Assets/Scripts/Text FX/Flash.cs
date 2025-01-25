using UnityEngine;
using TMPro;
using System;
using System.Collections;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Flash : MonoBehaviour
{

  [Header("Flash Settings")]

  [SerializeField]
  [Range(0.0f, 1.0f)] private float opacity = 1f;

  [SerializeField]
  [Range(0.5f, 2.0f)] private float flashSpeed = 1f;

  private TextMeshProUGUI textMesh;

  private void Start()
  {
    if (!textMesh)
      textMesh = GetComponent<TextMeshProUGUI>();

    textMesh.alpha = opacity;
    StartCoroutine(FlashText());
  }

private IEnumerator FlashText()
{
  while (true)
  {
    float elapsedTime = 0f;
    float duration = 1f;
    
    while (elapsedTime < duration)
    {
      elapsedTime += flashSpeed * Time.deltaTime;
      opacity = Mathf.Lerp(0, 1, elapsedTime / duration);
      textMesh.alpha = opacity;
      yield return null;
    }
    
    elapsedTime = 0f;
    while (elapsedTime < duration)
    {
      elapsedTime += Time.deltaTime;
      opacity = Mathf.Lerp(1, 0, elapsedTime / duration);
      textMesh.alpha = opacity;
      yield return null;
    }
  }
}
}
