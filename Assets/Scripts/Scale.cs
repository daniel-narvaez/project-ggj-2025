using UnityEngine;

public class Scale : MonoBehaviour
{
    public float minScale = 0.5f; // Minimum scale when at the bottom of the screen
    public float maxScale = 2f;   // Maximum scale when at the top of the screen
    public float currentScale = 1f; // Current scale for EDPlayerMovement

    private Camera mainCamera;

    void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Convert the object's world position to screen position
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(transform.position);

        // Calculate the vertical screen position as a value between 0 and 1
        float normalizedYPosition = Mathf.InverseLerp(0, Screen.height, screenPosition.y);

        // Map the normalized Y position to the desired scale range, and set
        float targetScale = Mathf.Lerp(minScale, maxScale, normalizedYPosition);
        currentScale = targetScale;

        // Apply the scaling
        transform.localScale = new Vector3(targetScale, targetScale, targetScale);
    }
}
