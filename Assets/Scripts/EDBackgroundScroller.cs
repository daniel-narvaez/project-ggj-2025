using UnityEngine;

public class EDBackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f; // Speed at which the background moves
    public float resetPositionY = -10f; // The Y position where the background resets to create the looping effect
    public float startPositionY = 10f; // The initial Y position of the background model
    private Vector3 startPosition; // Starting position of the background

    private void Start()
    {
        // Store the initial position of the background object
        startPosition = transform.position;
        transform.position = new Vector3(startPosition.x, startPositionY, startPosition.z);
    }

    void Update()
    {
        // Move the background along the Y-axis (or Z-axis, based on your scene)
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        // If the background has moved past the reset position, reset it to create infinite scrolling
        if (transform.position.y <= resetPositionY)
        {
            // Reset the background position to the top (or depending on your setup, you can also reset the Z axis)
            transform.position = new Vector3(startPosition.x, startPositionY, startPosition.z);
        }
    }
}
