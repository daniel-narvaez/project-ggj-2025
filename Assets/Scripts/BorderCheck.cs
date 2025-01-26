using UnityEngine;

public class BorderCheck : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody playerRigidbody;

    void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;

        // Get the Rigidbody component (assuming the player has one)
        playerRigidbody = GetComponent<Rigidbody>();

        if (playerRigidbody == null)
        {
            Debug.LogError("Rigidbody not found on the player object. Please add one.");
        }
    }

    void Update()
    {
        // Convert player's position to viewport space
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // Check and handle boundaries
        if (viewportPosition.y <= 0) // Bottom of the screen
        {
            StopPlayer("Bottom");
        }
        else if (viewportPosition.y >= 1) // Top of the screen
        {
            StopPlayer("Top");
        }

        if (viewportPosition.x <= 0) // Left side of the screen
        {
            StopPlayer("Left");
        }
        else if (viewportPosition.x >= 1) // Right side of the screen
        {
            StopPlayer("Right");
        }
    }

    void StopPlayer(string boundary)
    {
        Debug.Log($"Player has hit the {boundary} boundary!");
        Player.Instance.OnPlayerTrigger();
        // Stop the player's movement
        if (playerRigidbody != null)
        {
            Vector3 clampedPosition = transform.position;

            // Adjust position to stay within the boundary
            if (boundary == "Bottom")
                Debug.Log("restart level");
            else if (boundary == "Top")
                clampedPosition.y = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 1f, transform.position.z)).y;
            else if (boundary == "Left")
                clampedPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0.5f, transform.position.z)).x;
            else if (boundary == "Right")
                clampedPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(1f, 0.5f, transform.position.z)).x;

            // Update the player's position and stop velocity
            transform.position = clampedPosition;
            playerRigidbody.velocity = Vector3.zero;
        }
    }
}
