using UnityEngine;

public class SpriteScaler : MonoBehaviour
{
    public float minScale = 0.5f; // Smallest scale at the bottom of the screen
    public float maxScale = 2f;  // Largest scale at the top of the screen
    public float currentScale; // Holder
    private float screenHeight;

    void Start()
    {
        // Get the height of the screen in world units
        screenHeight = Camera.main.orthographicSize * 2f;
    }

    void Update()
    {
        ScaleSpriteBasedOnPosition();
    }

    void ScaleSpriteBasedOnPosition()
    {
        // Get the sprite's Y position in world space
        float spriteY = transform.position.y;

        // Map the Y position to a 0-1 range based on screen height
        float normalizedY = Mathf.InverseLerp(-screenHeight / 2f, screenHeight / 2f, spriteY);

        // Calculate the scale based on the normalized Y value
        float newScale = Mathf.Lerp(minScale, maxScale, normalizedY);

        // Apply the scale to the sprite
        transform.localScale = new Vector3(newScale, newScale, 1f);

        currentScale = newScale;
    }
}
