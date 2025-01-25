using UnityEngine;
using TMPro;

public class Button : MonoBehaviour
{

  public TextMeshProUGUI span;

  void Awake()
  {
    if (!span)
      span =  GetComponentInChildren<TextMeshProUGUI>();

    span.color = new Color(241, 239, 254);
    span.fontStyle = FontStyles.Normal;
  }

  public void OnMouseEnter()
  {
    Debug.Log("enter");
    span.color = new Color(92, 62, 255);
    span.fontStyle = FontStyles.Bold;
  }

  public void OnMouseLeave()
  {
    Debug.Log("leave");
    span.color = new Color(241, 239, 254);
    span.fontStyle = FontStyles.Normal;
  }

  public void OnMouseDown()
  {
    Debug.Log("down");
    span.color = new Color(171, 48, 180);
    span.fontStyle = FontStyles.Bold;  
  }

  public void OnMouseUp()
  {
    Debug.Log("up");
    span.color = new Color(241, 239, 254);
    span.fontStyle = FontStyles.Bold;
  }
}
