using UnityEngine;

public class BorderCheck : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody rb;

    void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;
        // Get Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Convert player's position to viewport space
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // Check if the player is out of bounds
        if (viewportPosition.y <= 0) // Bottom of the screen
        {
            Debug.Log("Player has hit the bottom of the screen!");
            HandleBoundaryHit("Bottom");
        }
        else if (viewportPosition.y >= 1) // Top of the screen
        {
            Debug.Log("Player has hit the top of the screen!");
            HandleBoundaryHit("Top");
        }

        if (viewportPosition.x <= 0) // Left side of the screen
        {
            Debug.Log("Player has hit the left side of the screen!");
            HandleBoundaryHit("Left");
        }
        else if (viewportPosition.x >= 1) // Right side of the screen
        {
            Debug.Log("Player has hit the right side of the screen!");
            HandleBoundaryHit("Right");
        }
    }

    void HandleBoundaryHit(string boundary)
    {
        Vector3 clampedPosition = transform.position;

        // Adjust position to stay within the boundary
        if (boundary == "Bottom")
            Debug.Log("restart level");
        else if (boundary == "Top")
        {
            //clampedPosition.y = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 1f, transform.position.z)).y;
            rb.velocity = Vector3.zero;
        }
        else if (boundary == "Left")
        {
            //clampedPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0.5f, transform.position.z)).x;
            rb.velocity = Vector3.zero;
        }
        else if (boundary == "Right")
        {
            //clampedPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(1f, 0.5f, transform.position.z)).x;
            rb.velocity = Vector3.zero;
        }

        // Update the player's position and stop velocity
        //transform.position = clampedPosition;
        //rb.velocity = Vector3.zero;
    }
}
