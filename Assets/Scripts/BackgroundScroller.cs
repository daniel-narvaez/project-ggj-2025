using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;  // Speed of background scrolling
    private Vector3 startPos;
    private float height;

    void Start()
    {
        // Store the starting position and get the height of the background
        startPos = transform.position;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        // Scroll the background down over time
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

        // Reset position once it goes off-screen (e.g., below the camera)
        if (transform.position.y <= startPos.y - height)
        {
            transform.position = startPos;
        }
    }
}
