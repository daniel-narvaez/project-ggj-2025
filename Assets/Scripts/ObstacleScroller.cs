using UnityEngine;

public class ObstacleScroller : MonoBehaviour
{
    public float scrollSpeed = 3f;
    private float height;

    void Start()
    {
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        // Move the obstacle downward
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

        // Reset the position once it goes off-screen
        if (transform.position.y <= -Camera.main.orthographicSize - height)
        {
            // Reset to the top of the screen at a random x position
            transform.position = new Vector3(Random.Range(-5f, 5f), Camera.main.orthographicSize, 0);
        }
    }
}
